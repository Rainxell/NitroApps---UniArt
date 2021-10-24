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
    public class TemaController : ControllerBase
    {
        private readonly ITemaService _service;
        public TemaController(ITemaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<TemaDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<TemaDto>> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task Create([FromBody] TemaDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        public async Task<ActionResult<TemaDto>> PutArtista(int id, [FromBody] TemaDto request)
        {
            if (id != request.id)
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
