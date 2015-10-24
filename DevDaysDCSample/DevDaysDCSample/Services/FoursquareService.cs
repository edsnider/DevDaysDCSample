using System;
using System.Net.Http;
using System.Threading.Tasks;
using DevDaysDCSample.Models;
using DevDaysDCSample.Services.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevDaysDCSample.Services
{
    public class FoursquareService : IFoursquareService
    {
#region Foursquare API client props 
        private const string _CLIENT_ID = "MHZODVIJAWGPYYGJTWCO1ES1O0YNBDSSWZ2RYJGWNAJKBWZM"; 
        private const string _CLIENT_SECRET = "BUSJTOT2MT5WXLYJSOL5N4CAPGPLF2MF0TEXZBVZB2PQUVQ1"; 
#endregion 
        
        public async Task<VenuesResponse> GetVenues(string query, GeoCoords coords)
        { 
            var v = DateTime.Now.ToString("yyyyMMdd"); 

            var ll = $"{coords.Latitude},{coords.Longitude}"; 

			var url = string.Format ("https://api.foursquare.com/v2/venues/search?ll={0}&query={1}&client_id={2}&client_secret={3}&v={4}", ll, query, _CLIENT_ID, _CLIENT_SECRET, v);

            var client = new HttpClient(); 
            var response = await client.GetStringAsync(url); 

            var o = JObject.Parse(response); 

            return await Task.Factory.StartNew(() 
                => JsonConvert.DeserializeObject<VenuesResponse>(o["response"].ToString()));
        }
    }
}
