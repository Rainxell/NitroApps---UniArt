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
    public class Servicio_FormatoController : ControllerBase
    {
        private readonly IServicio_FormatoService _service;
        public Servicio_FormatoController(IServicio_FormatoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{servicioid:int}, {formatoid:int}")]
        public async Task<ResponseDto<Servicio_FormatoDto>> Get(int servicioid, int formatoid)
        {
            return await _service.Get(servicioid, formatoid);
        }

        [HttpPost]
        public async Task Create([FromBody] Servicio_FormatoDto request)
        {
            await _service.Create(request);

        }


    }
}
