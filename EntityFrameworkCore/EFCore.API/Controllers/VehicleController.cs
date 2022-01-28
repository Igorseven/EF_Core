using EFCore.Business.NotificationSettings;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Request.Vehicle;
using EFCore.ServiceApplication.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.API.Controllers
{
    //[EnableCors("Default")]
    [ApiController]
    [Route("v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;

        public VehicleController( IVehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("findall")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<IEnumerable<VehicleResponse>> Get()
        {
            return await this._vehicleService.FindAllAsync();
        }

        [HttpGet]
        [Route("find/{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<VehicleResponse> Get(int id)
        {
            return await this._vehicleService.FindByAsync(id);
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Post(VehicleRequest request)
        {
            await this._vehicleService.CreatAsync(request);
        }
    }
}
