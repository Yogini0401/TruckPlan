using DFDSTruckPlan.Models;
using DFDSTruckPlan.Models.AzureRestModels;
using Newtonsoft.Json;

namespace DFDSTruckPlan.Services
{
    public class AzureLocationService : ILocationService
    {
        private static readonly string subscriptionKey = "A4TemI5bmXKS68HpdBKErsP4qxn0nCdzFQIB1GJqI7j9c0n2el5CJQQJ99AIACi5YpzXfkziAAAgAZMP2ew3";
        private static readonly string baseUrl = "https://atlas.microsoft.com/route/directions/json";
        private static readonly string reverseGeocodeUrl = "https://atlas.microsoft.com/search/address/reverse/json";


        public async Task<double> GetDistance(Location origin, Location destination)
        {
            var originString = $"{origin.Latitude},{origin.Longitude}";
            var destinationString = $"{destination.Latitude},{destination.Longitude}";
            try
            {
                using var client = new HttpClient();

                string requestUrl = $"{baseUrl}?api-version=1.0&query={originString}:{destinationString}&subscription-key={subscriptionKey}";

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
            }
            return -1;
        }

        public async Task<LocationInfo> GetLocationInfo(Location origin)
        {
            var originString = $"{origin.Latitude},{origin.Longitude}";
            try
            {
                using var client = new HttpClient();

                // Construct the request URL
                string requestUrl = $"{reverseGeocodeUrl}?api-version=1.0&query={originString}&subscription-key={subscriptionKey}";

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
