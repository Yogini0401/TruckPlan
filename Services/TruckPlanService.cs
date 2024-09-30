using DFDSTruckPlan.DbContext;
using DFDSTruckPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace DFDSTruckPlan.Services
{
    public class TruckPlanService(ILocationService locationService, TruckPlanDbContext dbContext) : ITruckPlanService
    {
        public async Task<List<TruckPlan>> GetPlans()
        {
            var returnVal = await dbContext.TruckPlans.Include(p => p.Truck.GPSDevice.GPSPositions).ToListAsync();
            foreach (var truckPlan in returnVal)
            {
                truckPlan.TotalPlanDistance = await CalculateDistance(truckPlan);
            }
            return returnVal;
        }

        public async Task<TruckPlan> GetPlan(int id)
        {
            var truckPlan = await dbContext.TruckPlans
                .Include(p => p.Truck.GPSDevice.GPSPositions)
                .FirstAsync(p => p.Id == id);

            truckPlan.TotalPlanDistance = await CalculateDistance(truckPlan);
            return truckPlan;
        }

        public async Task<double> CalculateDistance(TruckPlan truckPlan)
        {
            double totalDistance = 0;
            var positions = truckPlan.Truck.GPSDevice.GPSPositions
                .Where(p => p.TimeStamp <= truckPlan.EndTime && p.TimeStamp >= truckPlan.StartTime)
                .ToList();

            if (positions.Count < 2)
            {
                return totalDistance;
            }

            for (int i = 0; i < positions.Count - 1; i++)
            {
                totalDistance += await locationService.GetDistance(new Location(positions[i]), new Location(positions[i + 1]));
            }

            return totalDistance;

        }

    }
}
