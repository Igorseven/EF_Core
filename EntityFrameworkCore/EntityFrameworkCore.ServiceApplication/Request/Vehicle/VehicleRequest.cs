using EFCore.ServiceApplication.Request.Manufacturer;

namespace EFCore.ServiceApplication.Request.Vehicle
{
    public class VehicleRequest
    {
        public string Model { get; set; }
        public string Information { get; set; }
        public decimal Price { get; set; }

        public ManufacturerRequest ManufacturerRequest { get; set; }
    }
}
