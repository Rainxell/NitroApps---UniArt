using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uniart.Dto;
using Uniart.Services;
using Uniart.Services.Variacion_DetalleServ;

namespace UniArt.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Variacion_DetalleController : ControllerBase
    {
        private readonly IVariacion_DetalleService _service;
        public Variacion_DetalleController(IVariacion_DetalleService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{Servicio_Variacion_id:int}, {Caracteristica_Opciones_id:int}")]
        public async Task<ResponseDto<Variacion_DetalleDto>> Get(int Servicio_Variacion_id, int Caracteristica_Opciones_id)
        {
            return await _service.Get(Servicio_Variacion_id, Caracteristica_Opciones_id);
        }

        [HttpPost]
        public async Task Create([FromBody] Variacion_DetalleDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        public async Task<ActionResult<ArtistaDto>> Put(int id, int id2,  [FromBody] Variacion_DetalleDto request)
        {
            if (id != request.Caracteristica_Opciones_id || id2 != request.Servicio_Variacion_id )
                return BadRequest();

            await _service.Update(request);
            return NoContent();
        }
    }
}
