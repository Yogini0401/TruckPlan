namespace DFDSTruckPlan.Models.AzureRestModels
{
    public class RouteResponse
    {
        public List<Route> Routes { get; set; }
    }

    public class Route
    {
        public RouteSummary Summary { get; set; }
    }

    public class RouteSummary
    {
        public double LengthInMeters { get; set; }
        public double TravelTimeInSeconds { get; set; }
    }
}
