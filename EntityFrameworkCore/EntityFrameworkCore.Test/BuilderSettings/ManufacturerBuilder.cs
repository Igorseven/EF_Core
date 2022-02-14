using EFCore.Domain.Entities;

namespace EFCore.Test.BuilderSettings
{
    public class ManufacturerBuilder
    {
        private int _id = 555;
        private string _name = "Ferrari";

        public static ManufacturerBuilder NewObject()
        {
            return new ManufacturerBuilder();
        }

        public ManufacturerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public Manufacturer Build()
        {
            return new Manufacturer { Id = _id, Name = _name };
        }
    }
}
