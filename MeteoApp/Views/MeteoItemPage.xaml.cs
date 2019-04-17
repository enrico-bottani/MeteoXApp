using MeteoApp.Models;
using Xamarin.Forms;
using Plugin.Geolocator;

using System;
using System.Diagnostics;
using Xamarin.Forms.Maps;
namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        private Location l;
        Geocoder geocoder;
        public MeteoItemPage()
        {
            InitializeComponent();
            GetLocation();
            l = new Location();
            BindingContext = l;
            geocoder = new Geocoder();

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
            var positions = new Position(position.Latitude, position.Longitude);
         
            
            var possibleAddresses = await geocoder.GetAddressesForPositionAsync(positions);
            
            foreach (var address in possibleAddresses)
            {
                Debug.WriteLine(address);
                l.Name = address;
                Debug.WriteLine("name is"+l.Name);
                
            }
               






        }
       


    }
}