using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uniart.Dto;
using Uniart.Services;

namespace UniArt.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _service;
        public CiudadController(ICiudadService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<CiudadDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<CiudadDto>> Get(int id)
        {
            return await _service.GetCiudad(id);
        }

        [HttpPost]
        public async Task Create([FromBody] CiudadDto request)
        {
            await _service.Create(request);
        }
    }
}
