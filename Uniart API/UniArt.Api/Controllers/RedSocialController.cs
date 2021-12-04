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
    public class RedSocialController : ControllerBase
    {
        private readonly IRed_SocialService _service;
        public RedSocialController(IRed_SocialService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Red_SocialDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<ResponseDto<Red_SocialDto>> Get(int id)
        {
            return await _service.GetRedes(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] Red_SocialDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<Red_SocialDto>> PutRedes(int id, [FromBody] Red_SocialDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Red_SocialDto>> Delete(int id)
        {
            var artistTodelete = _service.GetRedes(id);
            if (artistTodelete == null)
                return NotFound();
            await _service.Delete(id);
            return NoContent();
        }

    }
}
