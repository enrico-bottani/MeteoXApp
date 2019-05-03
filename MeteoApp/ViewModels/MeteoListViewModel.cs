using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MeteoApp.Models;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace MeteoApp
{
    public class MeteoListViewModel : BaseViewModel
    {
        ObservableCollection<Entry> _entries;
        private Location l;
        Geocoder geocoder;
        public ObservableCollection<Entry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public MeteoListViewModel()
        {
            Entries = new ObservableCollection<Entry>();

            var e = new Entry
            {
                ID = 0,
                Name = "Chiasso"
            };

            Entries.Add(e);

            e = new Entry
            {
                ID = 1,
                Name = "Zürich"
            };

            Entries.Add(e);
            
            GetLocation();
            
            // BindingContext = new MeteoItemViewModel(l);


        }
        async void GetLocation()
        {
            l = new Location();
            geocoder = new Xamarin.Forms.Maps.Geocoder();
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
                Debug.WriteLine("name is" + l.Name);

            }


            Debug.WriteLine("nameout is" + l.Name);
            var e = new Entry
            {
                ID = 3,
                Name = l.Name
            };
            Entries = new ObservableCollection<Entry>();
            Entries.Add(e);



        }
    }
}