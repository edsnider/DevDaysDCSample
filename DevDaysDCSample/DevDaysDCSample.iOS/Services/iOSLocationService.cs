using System.Threading.Tasks;
using DevDaysDCSample.iOS.Services;
using DevDaysDCSample.Models;
using DevDaysDCSample.Services;
using Xamarin.Geolocation;

[assembly: Xamarin.Forms.Dependency(typeof(iOSLocationService))]
namespace DevDaysDCSample.iOS.Services
{
    public class iOSLocationService : ILocationService
    {
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            var locator = new Geolocator { DesiredAccuracy = 30 };
            var position = await locator.GetPositionAsync(30000);
            
            var result = new GeoCoords
            {
                Latitude = position.Latitude, 
                Longitude = position.Longitude
            };

            return result;
        }
    }
}
