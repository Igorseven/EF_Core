using EFCore.Business.NotificationSettings;
using EFCore.ServiceApplication.Interfaces;
using EFCore.ServiceApplication.Request.Manufacturer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManufactureController : ControllerBase
    {
        private IManufacturerService _manufacturerService;

        public ManufactureController(IManufacturerService manufacturerService)
        {
            this._manufacturerService = manufacturerService;
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Post(ManufacturerRequest request)
        {
            await this._manufacturerService.CreateAsync(request);
        }
    }
}
