using EFCore.Domain.Entities;
using EFCore.ServiceApplication.AutoMapperSettings;
using EFCore.ServiceApplication.Request.Manufacturer;
using EFCore.ServiceApplication.Response;
using Xunit;

namespace EFCore.Test.AutoMapperTests
{
    public class ManufacturerAutoMapperTest
    {
        public Manufacturer Manufacturer;
        public ManufacturerRequest ManufacturerRequest;
        public ManufacturerUpdateRequest ManufacturerUpdate;
        public ManufacturerResponse ManufacturerResponse;

        public ManufacturerAutoMapperTest()
        {
            CreateManufacturer();
            CreateRequest();
            CreateUpdateRequest();
            CreateResponse();

            AutoMapperHandler.Inicialze();
        }

        private void CreateManufacturer()
        {
            this.Manufacturer = new Manufacturer
            {
                Id = 1,
                Name = "VW"
            };
        }

        private void CreateRequest()
        {
            this.ManufacturerRequest = new ManufacturerRequest
            {
                Name = "BMW"
            };
        }

        private void CreateUpdateRequest()
        {
            this.ManufacturerUpdate = new ManufacturerUpdateRequest
            {
                Id = 6,
                Name = "Ferrari"
            };
        }

        private void CreateResponse()
        {
            this.ManufacturerResponse = new ManufacturerResponse
            {
                Id = 110,
                Name = "Lamborgini"
            };
        }
    }

    [Collection("Valid State")]
    public class ManufacturerAutoMapperTest1 : ManufacturerAutoMapperTest
    {

        [Fact]
        [Trait("Domain to request", "Valid state")]
        public void ManufacturerDomainToRequest_WithAutoMapper_ResultValidState()
        {
            var manufacturer = this.Manufacturer;

            var request = this.Manufacturer.MapTo<Manufacturer, ManufacturerRequest>();

            Assert.Equal(request.Name, manufacturer.Name);
        }

        [Fact]
        [Trait("Request to Domain", "Valid state")]
        public void ManuFacturerRequestToDomain_WithAutoMapper_ResultValidState()
        {
            var request = this.ManufacturerRequest;

            var manufacturer = this.ManufacturerRequest.MapTo<ManufacturerRequest, Manufacturer>();

            Assert.Equal(manufacturer.Name, request.Name);
        }

        [Fact]
        [Trait("Domain to Update Request", "Valid state")]
        public void ManufacturerDomainToUpdateRequest_WithAutoMapper_ResultValidState()
        {
            var manufacturer = this.Manufacturer;

            var update = this.Manufacturer.MapTo<Manufacturer, ManufacturerUpdateRequest>();

            Assert.Equal(update.Id, manufacturer.Id);
            Assert.Equal(update.Name, manufacturer.Name);
        }

        [Fact]
        [Trait("Update Request to Domain", "Valid state")]
        public void ManufactuerUpdateRequestToDomain_WhitAutoMapper_ResultValidState()
        {
            var update = this.ManufacturerUpdate;

            var manufacturer = this.ManufacturerUpdate.MapTo<ManufacturerUpdateRequest, Manufacturer>();

            Assert.Equal(manufacturer.Id, update.Id);
            Assert.Equal(manufacturer.Name, update.Name);
        }

        [Fact]
        [Trait("Domain to Response", "Valid state")]
        public void ManufacturerDomainToResponse_WithAutoMapper_ResultValidState()
        {
            var manufacturer = this.Manufacturer;

            var response = this.Manufacturer.MapTo<Manufacturer, ManufacturerResponse>();

            Assert.Equal(response.Id, manufacturer.Id);
            Assert.Equal(response.Name, manufacturer.Name);
        }
    }
}
