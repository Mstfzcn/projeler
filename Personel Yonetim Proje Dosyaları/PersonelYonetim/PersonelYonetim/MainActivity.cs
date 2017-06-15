using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using System.Net;
using Android.Content;

namespace PersonelYonetim
{
    [Activity(Label = "Personel Otomasyonu", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            EditText kAdi = FindViewById<EditText>(Resource.Id.editTextKAdi);
            EditText sifre = FindViewById<EditText>(Resource.Id.editTextSifre);
            Button girisButon = FindViewById<Button>(Resource.Id.buttonGiris);
            

            girisButon.Click += async (sender, e) =>
            {
                string url = "http://185.87.123.69/personelBilgi.aspx?kAdi=" + kAdi.Text; //personelYonetimApi projesinin atıldığı Web servis adresi

                try
                {
                    JsonValue json = await FetchDataAsync(url);
                    string kSifre = json["sifre"];
                    

                    var girisDialog = new AlertDialog.Builder(this);
                    if (sifre.Text.Equals(kSifre))
                    {
                        var intent = new Intent(this, typeof(BilgilerActivity));
                        intent.PutExtra("ad", json["kAdi"].ToString().ToUpper().Replace('"', ' '));
                        intent.PutExtra("soyad", json["soyad"].ToString().ToUpper().Replace('"', ' '));
                        intent.PutExtra("unvan", json["unvan"].ToString().ToUpper().Replace('"', ' '));
                        intent.PutExtra("gorev", json["gorev"].ToString().ToUpper().Replace('"', ' '));
                        intent.PutExtra("sonTarih", json["sonTarih"].ToString().Replace('"', ' '));
                        StartActivity(intent);
                    }
                    else
                    {
                        girisDialog.SetMessage("Hatalı Şifre!");
                    }
                    girisDialog.Show();
                }
                catch (Exception ex)
                {
                    var hataDialog = new AlertDialog.Builder(this);
                    hataDialog.SetMessage("Hatalı Giriş Yaptınız!\n" + ex.Message);
                    hataDialog.Show();
                    Console.WriteLine("Hata : " + ex.Message);
                }
                
            };
        }
        
        private async Task<JsonValue> FetchDataAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                    
                    return jsonDoc;
                }
            }
        }

    }
}

