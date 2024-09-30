using DFDSTruckPlan.Models;

namespace DFDSTruckPlan.Services
{
    public interface ITruckPlanService
    {
        Task<List<TruckPlan>> GetPlans();
        Task<TruckPlan> GetPlan(int id);
        public Task<double> CalculateDistance(TruckPlan truckPlan);

    }
}
