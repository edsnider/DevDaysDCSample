using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DevDaysDCSample.Models;
using DevDaysDCSample.Services;
using Xamarin.Forms;

namespace DevDaysDCSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IFoursquareService _foursquare; 
        private readonly ILocationService _location; 

        private ObservableCollection<Venue> _venues; 
        public ObservableCollection<Venue> Venues 
        { 
            get { return _venues; } 
            set 
            { 
                _venues = value; 
                OnPropertyChanged(); 
            } 
        } 

        private GeoCoords _currentLocation; 
        public GeoCoords CurrentLocation
        { 
            get { return _currentLocation; } 
            set 
            { 
                _currentLocation = value; 
                OnPropertyChanged(); 
            } 
        }

        private Command _refreshCommand;
        public Command RefreshCommand
        {
            get { return _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }

        public MainViewModel()
        { 
            Venues = new ObservableCollection<Venue>(); 

            // TODO: constructor injection 
            _foursquare = new FoursquareService(); 
            _location = DependencyService.Get<ILocationService>(); 
        } 
        
        private async Task ExecuteRefreshCommand()
        { 
            if (IsBusy) return; 

            //CurrentLocation  = new GeoCoords { Latitude = 38.954577, Longitude = -77.346357 }; // Reston VA 
            CurrentLocation = await _location.GetGeoCoordinatesAsync(); 
            
            await LoadVenues(); 
        }

        private async Task LoadVenues()
        { 
            if (IsBusy) return; 
            IsBusy = true; 

            Venues.Clear();

            try
            {
                var response = await _foursquare.GetVenues("coffee", CurrentLocation);
                //var response = new VenuesResponse();
                //response.Venues = new List<Venue>();
                //response.Venues.Add(new Venue
                //{
                //    Name = "Test 1",
                //    Id = "1",
                //    Address = new VenueAddress {Address = "123 Main Street", City = "Somewhere", State = "VA"}
                //});
                //response.Venues.Add(new Venue
                //{
                //    Name = "Test 2",
                //    Id = "2",
                //    Address = new VenueAddress {Address = "123 Main Street", City = "Somewhere", State = "VA"}
                //});

                foreach (var v in response.Venues)
                    Venues.Add(v);
            }
            finally 
            { 
                IsBusy = false; 
            } 
        } 
    }
}