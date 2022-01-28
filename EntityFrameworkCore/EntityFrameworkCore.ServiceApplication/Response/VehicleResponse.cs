using EFCore.ServiceApplication.Request.Manufacturer;

namespace EFCore.ServiceApplication.Response
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Information { get; set; }
        public decimal Price { get; set; }

        public ManufacturerResponse ManufacturerResponse { get; set; }
    }
}
