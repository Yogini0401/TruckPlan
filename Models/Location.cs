namespace DFDSTruckPlan.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(string origin)
        {

            Latitude = Convert.ToDouble(origin.Split(',')[0]);
            Longitude = Convert.ToDouble(origin.Split(',')[1]);

        }

        public Location(GPSPosition gPSPosition)
        {
            Latitude = gPSPosition.Latitude;
            Longitude = gPSPosition.Longitude;
        }
    }

}