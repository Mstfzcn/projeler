using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Util;
using Android.Graphics;
using System.Collections.Generic;

namespace TravelDiary
{
    [Activity(Label = "Travel Diary", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/worldwide_location")]
    public class MainActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        private GoogleMap gMap;
        LocationManager locMgr;
        string tag = "MainActivity";
        string latitude;
        string longitude;
        string provider;
        EditText locationName;
        string location = "?";
        Button buttonKaydet;
        Button buttonHistoryLocation;
        Button buttonExit;
        MarkerOptions options = new MarkerOptions();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            buttonKaydet = FindViewById<Button>(Resource.Id.btnKaydet);
            locationName = FindViewById<EditText>(Resource.Id.editTextLocationName);
            buttonHistoryLocation = FindViewById<Button>(Resource.Id.btnHistoryLocation);
            buttonExit = FindViewById<Button>(Resource.Id.buttonExit);

            if (Intent.Extras != null)
            {
                location = Intent.Extras.Get("locationName").ToString(); // ?? new string[0];
                latitude = Intent.Extras.Get("latitude").ToString(); // ?? new string[0];
                longitude = Intent.Extras.Get("longitude").ToString(); // ?? new string[0];
                SetUpMap();
            }
            else
            {
                myLocation();
            }
        }

        private void myLocation()
        {
            locMgr = GetSystemService(Context.LocationService) as LocationManager;

            if (locMgr.AllProviders.Contains(LocationManager.NetworkProvider)
                    && locMgr.IsProviderEnabled(LocationManager.NetworkProvider))
            {
                locMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 2000, 1, this);
            }
            else
            {
                Toast.MakeText(this, "The Network Provider does not exist or is not enabled!", ToastLength.Long).Show();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(tag, "OnStart called");
        }

        // OnResume gets called every time the activity starts, so we'll put our RequestLocationUpdates
        // code here, so that 
        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(tag, "OnResume called");

            buttonKaydet.Click += (sender, e) =>
            {
                location = locationName.Text;
                var intent = new Intent(this, typeof(HistoryLocationActivity));
                intent.PutExtra("locationName", locationName.Text);
                intent.PutExtra("latitude", latitude);
                intent.PutExtra("longitude", longitude);
                StartActivity(intent);
            };

            buttonHistoryLocation.Click += (sender, e) =>
            {
                StartActivity(typeof(HistoryLocationActivity));
            };

            buttonExit.Click += (sender, e) =>
            {
                this.FinishAffinity();
            };
            
        }

        protected override void OnPause()
        {
            base.OnPause();
            
            // RemoveUpdates takes a pending intent - here, we pass the current Activity
            locMgr.RemoveUpdates(this);
            Log.Debug(tag, "Location updates paused because application is entering the background");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(tag, "OnStop called");
        }

        public void OnLocationChanged(Android.Locations.Location location)
        {
            Log.Debug(tag, "Location changed");
            latitude = location.Latitude.ToString();
            longitude = location.Longitude.ToString();
            provider = location.Provider.ToString();
            SetUpMap();
        }
        public void OnProviderDisabled(string provider)
        {
            Log.Debug(tag, provider + " disabled by user");
        }
        public void OnProviderEnabled(string provider)
        {
            Log.Debug(tag, provider + " enabled by user");
        }
        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            Log.Debug(tag, provider + " availability has changed to " + status.ToString());
        }

        private void SetUpMap()
        {
            FragmentManager.FindFragmentById<MapFragment>(Resource.Id.fragmentMap).GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            this.gMap = googleMap;
            LatLng latlng = new LatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            gMap.MoveCamera(camera);
            options.SetPosition(latlng).SetTitle(location);
            gMap.AddMarker(options);
        }
    }

    
}

