using System.ComponentModel.DataAnnotations.Schema;

namespace DFDSTruckPlan.Models
{
    public class TruckPlan
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        public Driver Driver { get; set; }
        public Truck Truck { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [NotMapped]
        public double TotalPlanDistance { get; set; }   

    }
}
