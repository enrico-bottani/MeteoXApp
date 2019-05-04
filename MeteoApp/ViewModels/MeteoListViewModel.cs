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
#if __IOS__
            Xamarin.FormsMaps.Init();
#endif

            foreach(var i in App.Database.GetEntrys()) {
                var e = new Entry
                {
                    ID = i.ID,
                    Name = i.Name
                };

                Entries.Add(e);
            }


            GetLocation();
        }
        async void GetLocation()
        {
            Location l = new Location();
            Geocoder geocoder = new Geocoder();
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
            e.Lat = position.Latitude;
            e.Lon = position.Longitude;
            Entries.Add(e);
        }
    }


}