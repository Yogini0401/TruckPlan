using DFDSTruckPlan.Models;
using DFDSTruckPlan.Models.Filter;
using DFDSTruckPlan.Services;
using Microsoft.AspNetCore.Mvc;

namespace DFDSTruckPlan.Controllers
{
    public class TruckPlanController(ITruckPlanService truckPlanService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult<List<TruckPlan>>> GetPlans()
        {
            try
            {
                return await truckPlanService.GetPlans();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TruckPlan>> GetPlan([FromRoute] int id)
        {
            try
            {
                return await truckPlanService.GetPlan(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("customQuery")]
        public async Task<ActionResult<double>> GetPlan(CustomFilter filter)
        {
            try
            {
                return (await truckPlanService.GetPlans())
                    .Where(p => p.Driver.Age >= filter.DriverAge)
                    .Where(p => p.StartTime <= filter.StartTime && p.EndTime >= filter.EndTime)
                    .Select(p => p.TotalPlanDistance)
                    .Sum();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
