using DFDSTruckPlan.Models;

namespace DFDSTruckPlan.Services
{
    public interface ILocationService    
    {
        public Task<double> GetDistance(Location origin, Location destination);
        public Task<LocationInfo> GetLocationInfo(Location location);
    }
    
}
