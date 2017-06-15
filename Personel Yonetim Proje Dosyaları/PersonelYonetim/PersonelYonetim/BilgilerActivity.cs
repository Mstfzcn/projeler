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
using System.Net;
using System.Json;
using System.IO;
using System.Threading.Tasks;

namespace PersonelYonetim
{
    [Activity(Label = "BilgilerActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class BilgilerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Bilgiler);
            // Create your application here

            TextView ad = FindViewById<TextView>(Resource.Id.textViewAd);
            TextView soyad = FindViewById<TextView>(Resource.Id.textViewSoyad);
            TextView unvan = FindViewById<TextView>(Resource.Id.textViewUnvan);
            TextView gorev = FindViewById<TextView>(Resource.Id.textViewGorev);
            TextView sonTarih = FindViewById<TextView>(Resource.Id.textViewSonTarih);

            ad.Text = Intent.GetStringExtra("ad") ?? "Data not available";
            soyad.Text = Intent.GetStringExtra("soyad") ?? "Data not available";
            unvan.Text = Intent.GetStringExtra("unvan") ?? "Data not available";
            gorev.Text = Intent.GetStringExtra("gorev") ?? "Data not available";
            sonTarih.Text = Intent.GetStringExtra("sonTarih") ?? "Data not available";

        }
    }
}