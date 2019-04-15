using MeteoApp.Models;
using Xamarin.Forms;
using Plugin.Geolocator;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        private Location l;
        public MeteoItemPage()
        {
            InitializeComponent();
            GetLocation();
            l = new Location();
            BindingContext = l;

        }

  

        async void GetLocation()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            l.Latitude = position.Latitude;
            l.Longitude = position.Longitude;
            
            Debug.WriteLine("Position Status: {0}", position.Timestamp);
            Debug.WriteLine("Position Latitude: {0}", position.Latitude);
            Debug.WriteLine("Position Longitude: {0}", position.Longitude);
            Debug.WriteLine("ID: {0}", l.ID);
           


        }
        

    }
}