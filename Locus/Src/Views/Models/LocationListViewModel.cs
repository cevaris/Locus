using System;
using System.Collections.ObjectModel;

namespace Locus.Views.Models
{
    public class LocationListViewModel
    {
        public ObservableCollection<LocationListRecordViewModel> LocationList { get; set; }

        public LocationListViewModel()
        {
            LocationList = new ObservableCollection<LocationListRecordViewModel>();
        }

        public static LocationListViewModel Preview = new LocationListViewModel()
        {
            LocationList = new ObservableCollection<LocationListRecordViewModel>()
            {
                new LocationListRecordViewModel()
                {
                    Name = "Home",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                },
                new LocationListRecordViewModel()
                {
                    Name = "Work",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                },
                new LocationListRecordViewModel()
                {
                    Name = "Car",
                    CreatedAt = DateTime.UtcNow.AddHours(-5)
                },
            }
        };
    }

    public class LocationListRecordViewModel
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

