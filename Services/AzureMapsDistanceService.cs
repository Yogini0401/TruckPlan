using DFDSTruckPlan.Config;
using DFDSTruckPlan.Models;
using DFDSTruckPlan.Models.AzureRestModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DFDSTruckPlan.Services
{
    public class AzureLocationService : ILocationService
    {
        private readonly AzureMaps _azureMaps;
        public AzureLocationService(IOptions<AzureMaps> azureMaps) {
            _azureMaps = azureMaps.Value;
        }

        public async Task<double> GetDistance(Location origin, Location destination)
        {
            var originString = $"{origin.Latitude},{origin.Longitude}";
            var destinationString = $"{destination.Latitude},{destination.Longitude}";
            try
            {
                using var client = new HttpClient();

                string requestUrl = $"{_azureMaps.BaseUrl}?api-version=1.0&query={originString}:{destinationString}&subscription-key={_azureMaps.SubscriptionKey}";

                var response = await client.GetAsync(requestUrl);

                string result = await response.Content.ReadAsStringAsync();
                var routeResponse = JsonConvert.DeserializeObject<RouteResponse>(result);
                if (routeResponse?.Routes != null && routeResponse?.Routes?.Count > 0)
                {
                    double distanceInMeters = routeResponse.Routes[0].Summary.LengthInMeters;
                    return distanceInMeters / 1000;
                }
                else
                {
                    throw new Exception("No routes found in the response.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<LocationInfo> GetLocationInfo(Location origin)
        {
            var originString = $"{origin.Latitude},{origin.Longitude}";
            try
            {
                using var client = new HttpClient();

                // Construct the request URL
                string requestUrl = $"{_azureMaps.ReverseGeocodeUrl}?api-version=1.0&query={originString}&subscription-key={_azureMaps.SubscriptionKey}";

                var response = await client.GetAsync(requestUrl);
                string result = await response.Content.ReadAsStringAsync();
                var reverseGeocodeResponse = JsonConvert.DeserializeObject<ReverseGeocodeResponse>(result);
                if (reverseGeocodeResponse?.Addresses != null && reverseGeocodeResponse.Addresses.Count > 0)
                {
                    var country = reverseGeocodeResponse.Addresses[0].Address.Country;
                    return new LocationInfo { countryName = country };
                }
                else
                {
                    throw new Exception("No address information found for the given coordinates.");
                }
            }
            catch (Exception ex)
            {
                //throw;
            }

            return new LocationInfo { countryName = "Unknown" };
        }
    }
}
