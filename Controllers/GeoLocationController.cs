using DFDSTruckPlan.Models;
using DFDSTruckPlan.Services;
using Microsoft.AspNetCore.Mvc;

namespace DFDSTruckPlan.Controllers
{
    public class GeoLocationController(ILocationService ILocationService) : ControllerBase
    {

        [HttpGet("distance")]
        public async Task<ActionResult> GetDistance(string origin = "52.5200,13.4050", string destination = "48.8566,2.3522")
        {
            try
            {
                var originLocation = new Location(origin);
                var destinationLocation = new Location(destination);
                
                var distanceData = await ILocationService.GetDistance(originLocation, destinationLocation);
                return Ok($"{distanceData} Kilometers");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }

        [HttpGet("location")]
        public async Task<ActionResult> GetLocationName(string origin = "52.5200,13.4050")
        {
            try
            {
                var coordinate = new Location(origin);

                var locationInfo = await ILocationService.GetLocationInfo(coordinate);
                return Ok($"{locationInfo.countryName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
