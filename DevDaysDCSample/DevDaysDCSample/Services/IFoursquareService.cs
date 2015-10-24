using System.Threading.Tasks;
using DevDaysDCSample.Models;
using DevDaysDCSample.Services.ResponseModels;

namespace DevDaysDCSample.Services
{
    public interface IFoursquareService
    {
        Task<VenuesResponse> GetVenues(string query, GeoCoords coords);
    }
}
