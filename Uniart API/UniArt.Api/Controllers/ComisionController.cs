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
    public class ComisionController: ControllerBase
    {
        private readonly IComisionService _service;
        public ComisionController(IComisionService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<ComisionDto>> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task Create([FromBody] ComisionDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        public async Task<ActionResult<ComisionDto>> PutArtista(int id, [FromBody] ComisionDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ComisionDto>> Delete(int id)
        {
            var artistTodelete = _service.Get(id);
            if (artistTodelete == null)
                return NotFound();
            await _service.Delete(artistTodelete.Id);
            return NoContent();
        }
    }
}
