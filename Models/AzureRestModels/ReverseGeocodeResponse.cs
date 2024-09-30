namespace DFDSTruckPlan.Models.AzureRestModels
{
    public class ReverseGeocodeResponse
    {
        public List<ReverseGeocodeAddress> Addresses { get; set; }
    }

    public class ReverseGeocodeAddress
    {
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
    }
}
