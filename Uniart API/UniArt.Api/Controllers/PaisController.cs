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
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;
        public PaisController(IPaisService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<PaisDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<ResponseDto<PaisDto>> Get(int id)
        {
            return await _service.GetPais(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] PaisDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<PaisDto>> PutArtista(int id, [FromBody] PaisDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<PaisDto>> Delete(int id)
        {
            var paisToDelete = _service.GetPais(id);
            if (paisToDelete == null)
                return NotFound();
            await _service.Delete(id);
            return NoContent();
        }
    }
}
