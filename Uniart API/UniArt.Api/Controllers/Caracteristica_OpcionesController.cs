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
    public class Caracteristica_OpcionesController : ControllerBase
    {
        private readonly ICaracteristicas_OpcionesService _service;
        public Caracteristica_OpcionesController(ICaracteristicas_OpcionesService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Caracteristica_OpcionesDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<ResponseDto<Caracteristica_OpcionesDto>> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] Caracteristica_OpcionesDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<Caracteristica_OpcionesDto>> PutArtista(int id, [FromBody] Caracteristica_OpcionesDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Caracteristica_OpcionesDto>> Delete(int id)
        {
            var artistTodelete = _service.Get(id);
            if (artistTodelete == null)
                return NotFound();
            await _service.Delete(id);
            return NoContent();
        }
    }
}
