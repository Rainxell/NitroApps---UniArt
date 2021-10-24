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
    public class Servicio_VariacionController : ControllerBase
    {
        private readonly IServicio_VariacionService _service;
        public Servicio_VariacionController(IServicio_VariacionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Servicio_VariacionDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<Servicio_VariacionDto>> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task Create([FromBody] Servicio_VariacionDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        public async Task<ActionResult<Servicio_VariacionDto>> PutArtista(int id, [FromBody] Servicio_VariacionDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ArtistaDto>> Delete(int id)
        {
            var artistTodelete = _service.Get(id);
            if (artistTodelete == null)
                return NotFound();
            await _service.Delete(artistTodelete.Id);
            return NoContent();
        }

    }
}
