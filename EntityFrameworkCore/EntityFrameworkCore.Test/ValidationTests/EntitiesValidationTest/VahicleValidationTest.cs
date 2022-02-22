using EFCore.Business.Validation;
using EFCore.Domain.EntitiesValidation;
using EFCore.Test.BuilderSettings;
using Xunit;

namespace EFCore.Test.ValidationTests.EntitiesValidationTest
{
    public class VahicleValidationTest 
    {
        private DomainValidation _validation;

        public VahicleValidationTest()
        {
            _validation = new DomainValidation();
        }

        [Fact]
        [Trait("Properties Validation", "Valid state")]
        public void VehicleValidation_WithPropertiesValids_ValidState()
        {
            var vehicle = VehicleBuilder.NewObject().DomainVehicleBuild();

            bool result = _validation.Validate(vehicle, new VehicleValidation());

            Assert.True(result);
        }

        [Theory]
        [Trait("Property Model Validation", "Invalid State")]
        [InlineData("")]
        [InlineData("H")]
        [InlineData("Testanto o max length da propriedade Model")]
        public void VehicleValidation_WithModelPropertyInvalid_InvalidState(string model)
        {
            var vehicle = VehicleBuilder.NewObject().WithModel(model).DomainVehicleBuild();

            bool result = _validation.Validate(vehicle, new VehicleValidation());

            Assert.False(result);
        }

        [Theory]
        [Trait("Property Information Validation", "Invalid State")]
        [InlineData("")]
        [InlineData("I")]
        [InlineData("In")]
        public void VehicleValidation_WithInformationPropertyInvalid_InvalidState(string information)
        {
            var vehicle = VehicleBuilder.NewObject().WithInformation(information).DomainVehicleBuild();

            bool result = _validation.Validate(vehicle, new VehicleValidation());

            Assert.False(result);
        }


        [Theory]
        [Trait("Property Price Validation", "Invalid State")]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(-1)]
        public void VehicleValidation_WithPriceInvalid_InvalidState(decimal price)
        {
            var vehicle = VehicleBuilder.NewObject().WithPrice(price).DomainVehicleBuild();

            bool result = _validation.Validate(vehicle, new VehicleValidation());

            Assert.False(result);
        }
    }
}
