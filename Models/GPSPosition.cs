

namespace DFDSTruckPlan.Models
{
    public class GPSPosition
    {
        public int Id { get; set; }

        public int GPSDeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
