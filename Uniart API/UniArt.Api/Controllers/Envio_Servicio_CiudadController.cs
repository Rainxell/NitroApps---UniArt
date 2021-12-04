using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class Envio_Servicio_CiudadController : ControllerBase
    {
        private readonly IEnvio_Servicio_CiudadService _service;
        public Envio_Servicio_CiudadController(IEnvio_Servicio_CiudadService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("{servicioid:int},{ciudadid:int} ")]
        public async Task<ResponseDto<Envio_Servicio_CiudadDto>> Get(int servicioid, int ciudadid)
        {
            return await _service.Get(servicioid, ciudadid);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] Envio_Servicio_CiudadDto request)
        {
            await _service.Create(request);

        }

    }
}
