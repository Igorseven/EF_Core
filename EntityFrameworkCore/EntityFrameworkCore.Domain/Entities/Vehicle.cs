namespace EFCore.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Model { get; set; }
        public string Information { get; set; }
        public decimal Price { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
