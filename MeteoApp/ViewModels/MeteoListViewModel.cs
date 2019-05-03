using System;
using System.Collections.ObjectModel;

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

            e = new Entry
            {
                ID = 2,
                Name = "Roma"
            };

            Entries.Add(e);
           
             e = new Entry
            {
                ID = 3,
                Name = "Miami"
            };

            Entries.Add(e);
        }
    }
}