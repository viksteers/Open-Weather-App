using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenWeather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            LblCityName.Text = WeatherGV.CityName; // displays city name
            LblTemp.Text = $"Current Temp: {WeatherGV.CurTemp}°F"; // displays temp
            LblLowTemp.Text = $"Low Temp: {WeatherGV.LowTemp}°F"; // displays low temp
            LblHighTemp.Text = $"High Temp: {WeatherGV.HighTemp}°F"; // displays high temp
        }
    }
}