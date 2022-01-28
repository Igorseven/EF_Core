using EFCore.ServiceApplication.Request.Manufacturer;

namespace EFCore.ServiceApplication.Request.Vehicle
{
    public class VehicleUpdateRequest
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Information { get; set; }
        public decimal Price { get; set; }

        public ManufacturerUpdateRequest ManufacturerUpdateRequest { get; set; }
    }
}
