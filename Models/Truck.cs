namespace DFDSTruckPlan.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public int GPSDeviceId { get; set; }
        public GPSDevice GPSDevice { get; set; }
    }
}
