namespace DFDSTruckPlan.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age => DateTime.Now.Year - Birthdate.Year;
    }
}
