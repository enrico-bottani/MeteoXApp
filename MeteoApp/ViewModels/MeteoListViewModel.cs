using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MeteoApp.Models;

namespace MeteoApp
{
    public class MeteoListViewModel : BaseViewModel
    {
        ObservableCollection<Models.Location> _entries;

        
        // committami
        public ObservableCollection<Models.Location> Entries
        {
            get => _entries;
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public MeteoListViewModel()
        {
            Entries = new ObservableCollection<Models.Location>();

            foreach (var l in App.Database.GetLocations())
            {
                var e = new Models.Location
                {
                    ID = l.ID,
                    Name = l.Name
                };

                Entries.Add(e);
            }
        }

        private static List<Models.Location> getLocations()
        {
            return App.Database.GetLocations();
        }
    }
}