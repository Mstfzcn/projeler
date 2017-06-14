using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Util;
using SQLite;
using System.IO;
using System.Threading;

namespace TravelDiary
{
    [Activity(Label = "HistoryLocationActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class HistoryLocationActivity : Activity
    {
        List<LocationItem> locationItem = new List<LocationItem>();
        ListView listView;
        string locationName;
        string latitude;
        string longitude;
        TableQuery<LocationTable> data;
        Button btnGeri;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HistoryLocation);
            // Create your application here

            btnGeri = FindViewById<Button>(Resource.Id.buttonGeri);
            btnGeri.Click += BtnGeri_Click;

            if (Intent.Extras != null)
            {
                locationName = Intent.Extras.Get("locationName").ToString(); // ?? new string[0];
                latitude = Intent.Extras.Get("latitude").ToString(); // ?? new string[0];
                longitude = Intent.Extras.Get("longitude").ToString(); // ?? new string[0];

                LocationListAdd();
            }
            
            listView = FindViewById<ListView>(Resource.Id.myListView);
            //listView.Click += listView_Click;
            
            listView.Adapter = new LocationAdapter(this, LocationListShow());

            listView.ItemClick += listView_ItemClick;
        }

        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<LocationTable>(); //Call Table
                int pos = e.Position + 1;
                var data1 = data.Where(x => x.id == pos); //Linq Query  

                foreach (var value in data1)
                {
                    var intent = new Intent(this, typeof(MainActivity));
                    intent.PutExtra("locationName", value.locationName);
                    intent.PutExtra("latitude", value.latitude);
                    intent.PutExtra("longitude", value.longitude);
                    StartActivity(intent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
        

        private List<LocationItem> LocationListShow()
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<LocationTable>(); //Call Table
                
                foreach (var value in data)
                {
                    //Console.WriteLine("Location: " + value.id + " " + value.locationName);

                    locationItem.Add(new LocationItem()
                    {
                        location_name = value.locationName,
                        latitude_ = value.latitude,
                        longitude_ = value.longitude
                    });
                }
                    
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }

            return locationItem;
        }

        private void LocationListAdd()
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<LocationTable>();
                LocationTable tbl = new LocationTable();
                tbl.locationName = locationName;
                tbl.latitude = latitude;
                tbl.longitude = longitude;
                
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private TableQuery<LocationTable> GetLocationList()
        {
            
            return data;
        }
    }

    public class LocationAdapter : BaseAdapter<LocationItem>
    {
        List<LocationItem> items;
        Activity context;
        public LocationAdapter(Activity context, List<LocationItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override LocationItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.ListItem, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.location_name.ToUpper();
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.worldwide_location);//SetBackgroundColor(item.Color);

            return view;
        }
    }

    public class LocationItem
    {
        public string location_name { get; set; }
        public string latitude_ { get; set; }
        public string longitude_ { get; set; }
    }
}