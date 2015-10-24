using System.Threading.Tasks;
using DevDaysDCSample.Models;

namespace DevDaysDCSample.Services
{
    public interface ILocationService
    {
        Task<GeoCoords> GetGeoCoordinatesAsync();
    }
}