using EFCore.Domain.Entities;
using EFCore.ServiceApplication.AutoMapperSettings;
using EFCore.ServiceApplication.Request.Manufacturer;
using EFCore.ServiceApplication.Request.Vehicle;
using EFCore.ServiceApplication.Response;
using Xunit;

namespace EFCore.Test.AutoMapperTests
{
    public class VehicleAutoMapperTest
    {
        public Vehicle Vehicle;
        public VehicleRequest VehicleRequest;
        public VehicleUpdateRequest VehicleUpdate;
        public VehicleResponse VehicleResponse;

        public Manufacturer Manufacturer;
        public ManufacturerRequest ManufacturerRequest;
        public ManufacturerUpdateRequest ManufacturerUpdate;
        public ManufacturerResponse ManufacturerResponse;

        public VehicleAutoMapperTest()
        {
            CreateVehicle();
            CreateRequest();
            CreateUpdateRequest();
            CreateResponse();

            AutoMapperHandler.Inicialze();
        }


        private void CreateVehicle()
        {
            var manufacturer1 = this.Manufacturer = new Manufacturer
            {
                Id = 2,
                Name = "BMW"
            };

            this.Vehicle = new Vehicle
            {
                Id = 1,
                Model = "X6",
                Information = "Completo - 2018",
                Manufacturer = manufacturer1,
                Price = 536.000m
            };
        }

        private void CreateRequest()
        {
            var manufacturerRquest1 = this.ManufacturerRequest = new ManufacturerRequest
            {
                Name = "Mercedes-Benz"
            };

            this.VehicleRequest = new VehicleRequest
            {
                Model = "MB 755",
                Information = "Master Mb - 2020",
                ManufacturerRequest = manufacturerRquest1,
                Price = 399.000m
            };
        }

        private void CreateUpdateRequest()
        {
            var manufacturerUpdate1 = this.ManufacturerUpdate = new ManufacturerUpdateRequest
            {
                Id = 1,
                Name = "Mustang"
            };

            this.VehicleUpdate = new VehicleUpdateRequest
            {
                Id = 10,
                Model = "Cobra Shell v8",
                Information = "Top line - 2022",
                ManufacturerUpdateRequest = manufacturerUpdate1,
                Price = 399.000m
            };
        }

        private void CreateResponse()
        {
            var manufacturerResponse1 = this.ManufacturerResponse = new ManufacturerResponse
            {
                Id = 11,
                Name = "Fiat"
            };

            this.VehicleResponse = new VehicleResponse
            {
                Id = 10,
                Model = "Uno fire",
                Information = "EconoFlex - 2022",
                ManufacturerResponse = manufacturerResponse1,
                Price = 80.000m
            };
        }
    }

    [Collection("Valid State")]
    public class VehicleAutoMapperTest1 : VehicleAutoMapperTest
    {

        [Fact]
        [Trait("Domain to Request", "Valid state")]
        public void VehicleDomainToRequest_WithAutoMapper_ResultValidState()
        {
            var vehicle = this.Vehicle;
            var request = this.Vehicle.MapTo<Vehicle, VehicleRequest>();

            Assert.Equal(request.Model, vehicle.Model);
            Assert.Equal(request.Information, vehicle.Information);
            Assert.Equal(request.ManufacturerRequest.Name, vehicle.Manufacturer.Name);
            Assert.Equal(request.Price, vehicle.Price);
        }

        [Fact]
        [Trait("Request to Domain", "Valid state")]
        public void VehicleRequestToDomain_WithAutoMapper_ResultValidState()
        {
            var request = this.VehicleRequest;
            var vehicle = this.VehicleRequest.MapTo<VehicleRequest, Vehicle>();

            Assert.Equal(vehicle.Model, request.Model);
            Assert.Equal(vehicle.Information, request.Information);
            Assert.Equal(vehicle.Manufacturer.Name, request.ManufacturerRequest.Name);
            Assert.Equal(vehicle.Price, request.Price);
        }

        [Fact]
        [Trait("Domain to Update Request", "Valid state")]
        public void VehicleDomainToUpdateRequest_WithAutoMapper_ResultValidState()
        {
            var vehicle = this.Vehicle;
            var RequestUpdate = this.Vehicle.MapTo<Vehicle, VehicleUpdateRequest>();

            Assert.Equal(RequestUpdate.Model, vehicle.Model);
            Assert.Equal(RequestUpdate.Information, vehicle.Information);
            Assert.Equal(RequestUpdate.ManufacturerUpdateRequest.Name, vehicle.Manufacturer.Name);
            Assert.Equal(RequestUpdate.Price, vehicle.Price);
        }

        [Fact]
        [Trait("Update Request to Domain", "Valid state")]
        public void VehicleUpdateRequestToDomain_WithAutoMapper_ResultValidState()
        {
            var requestUpdate = this.VehicleUpdate;
            var vehicle = this.VehicleUpdate.MapTo<VehicleUpdateRequest, Vehicle>();

            Assert.Equal(vehicle.Model, requestUpdate.Model);
            Assert.Equal(vehicle.Information, requestUpdate.Information);
            Assert.Equal(vehicle.Manufacturer.Name, requestUpdate.ManufacturerUpdateRequest.Name);
            Assert.Equal(vehicle.Price, requestUpdate.Price);
        }


        [Fact]
        [Trait("Domain to Response", "Valid state")]
        public void VehicleDomainToResponse_WithAutoMapper_ResultValidState()
        {
            var vehicle = this.Vehicle;
            var response = this.Vehicle.MapTo<Vehicle, VehicleResponse>();

            Assert.Equal(response.Model, vehicle.Model);
            Assert.Equal(response.Information, vehicle.Information);
            Assert.Equal(response.ManufacturerResponse.Name, vehicle.Manufacturer.Name);
            Assert.Equal(response.Price, vehicle.Price);
        }

    }
}
