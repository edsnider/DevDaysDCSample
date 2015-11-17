using System;
using DevDaysDCSample.Services;
using System.Threading.Tasks;
using DevDaysDCSample.Models;
using Xamarin.Geolocation;
using Xamarin.Forms;
using DevDaysDCSample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidLocationService))]
namespace DevDaysDCSample.Droid
{
	public class AndroidLocationService : ILocationService
	{
		public async Task<GeoCoords> GetGeoCoordinatesAsync()
		{
			var locator = new Geolocator(Forms.Context) { DesiredAccuracy = 30 };
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

