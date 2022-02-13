using EFCore.Business.NotificationSettings;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Request.Manufacturer;
using EFCore.ServiceApplication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ManufactureController : ControllerBase
    {
        private IManufacturerService _manufacturerService;

        public ManufactureController(IManufacturerService manufacturerService)
        {
            this._manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("findAll")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<IEnumerable<ManufacturerResponse>> Get()
        {
            return await this._manufacturerService.FindAllAsync();
        }

        [HttpGet]
        [Route("find/{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<ManufacturerResponse> Get([FromQuery] int manufactureId)
        {
            return await this._manufacturerService.FindByAsync(manufactureId);
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Post([FromBody] ManufacturerRequest request)
        {
            await this._manufacturerService.CreateAsync(request);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Put([FromBody] ManufacturerUpdateRequest updateRequest)
        {
            await this._manufacturerService.UpdateAsync(updateRequest);
        }
    }
}
