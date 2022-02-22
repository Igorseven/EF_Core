using EFCore.Business.Validation;
using EFCore.Domain.EntitiesValidation;
using EFCore.Test.BuilderSettings;
using Xunit;

namespace EFCore.Test.ValidationTests.EntitiesValidationTest
{
    public class ManufacturerValidationTest
    {
        private DomainValidation _validation;

        public ManufacturerValidationTest()
        {
            this._validation = new DomainValidation();
        }

        [Fact]
        [Trait("Properties Validation", "Valid State")]
        public void ManufacturerValidation_WithPropertiesValid_ValidState()
        {
            var manufacturer = ManufacturerBuilder.NewObject().DomainManufacturerBuild();

            bool result = this._validation.Validate(manufacturer, new ManufacturerValidation());

            Assert.True(result);
        }

        [Theory]
        [Trait("Property Name Validation", "Invalid State")]
        [InlineData("")]
        [InlineData("M")]
        public void ManufacturerValidation_WithPropertyNameInvalid_InvalidState(string name)
        {
            var manufacturer = ManufacturerBuilder.NewObject().WithName(name).DomainManufacturerBuild();

            bool result = this._validation.Validate(manufacturer, new ManufacturerValidation());

            Assert.False(result);
        }
    }
}
