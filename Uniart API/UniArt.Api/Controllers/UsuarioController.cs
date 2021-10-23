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
    public class UsuarioController : ControllerBase
{
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<UsuarioDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<UsuarioDto>> Get(int id)
        {
            return await _service.GetUsuario(id);
        }

        [HttpPost]
        public async Task Create([FromBody] UsuarioDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody] UsuarioDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(id , request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UsuarioDto>> Delete(int id)
        {
            var userToDelete = _service.GetUsuario(id);
            if (userToDelete == null)
                return NotFound();
            await _service.Delete(userToDelete.Id);
            return NoContent();
        }
    }
}
