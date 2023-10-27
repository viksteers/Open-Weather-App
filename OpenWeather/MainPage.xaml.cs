using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenWeather
{
    public partial class MainPage : ContentPage
    {
        string APIKEY = "cee83df8adc10fed79e452806fdba5b6"; // string for apikey
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnShowTemp_Clicked(object sender, EventArgs e) // button clicked.
        {
            using (WebClient wc = new WebClient()) // new instance
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded"; // url
                try
                {
                    string jsontext = wc.DownloadString($"http://api.openweathermap.org/data/2.5/weather?zip={EntryZipCode.Text}&appid={APIKEY}&units=imperial"); // url for weather
                    JObject jo = JObject.Parse(jsontext); // gathers weather info
                    JObject main = JObject.Parse(jo["main"].ToString()); // gets info under main
                    WeatherGV.CurTemp = main["temp"].ToString(); // gathres current temp
                    WeatherGV.CityName = jo["name"].ToString(); // gathers city name
                    WeatherGV.LowTemp = main["temp_min"].ToString(); // gathers low temp
                    WeatherGV.HighTemp = main["temp_max"].ToString(); // gathers high temp
                    Navigation.PushAsync(new WeatherPage()); // navigates to new page
                }
                catch (Exception ex)
                {
                    DisplayAlert("Request Error", ex.Message, "Close."); // error code
                }
            }
        }
    }
}
