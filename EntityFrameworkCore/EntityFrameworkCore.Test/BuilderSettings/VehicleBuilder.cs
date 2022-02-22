using EFCore.Domain.Entities;

namespace EFCore.Test.BuilderSettings
{
    public class VehicleBuilder
    {
        private int _id = 55;
        private string _model = "X-6 MI";
        private string _information = "Super Class MI V6";
        private decimal _price = 750000.71m;
        private Manufacturer _manufacturer = new Manufacturer { Id = 100, Name = "BMW" };

        public static VehicleBuilder NewObject()
        {
            return new VehicleBuilder();
        }

        public VehicleBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public VehicleBuilder WithInformation(string information)
        {
            _information = information;
            return this;
        }

        public VehicleBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public Vehicle DomainVehicleBuild()
        {
            return new Vehicle 
            { 
                Id = _id,
                Model = _model,
                Information = _information,
                Price = _price,
                Manufacturer = _manufacturer 
            };
        }
        
    }
}
