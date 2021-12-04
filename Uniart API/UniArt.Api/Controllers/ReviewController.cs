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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ReviewDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<ResponseDto<ReviewDto>> Get(int id)
        {
            return await _service.GetArtista(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] ReviewDto request)
        {
            await _service.Create(request);

        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<ReviewDto>> PutArtista(int id, [FromBody] ReviewDto request)
        {
            if (id != request.Id)
                return BadRequest();

            await _service.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<ReviewDto>> Delete(int id)
        {
            var artistTodelete = _service.GetArtista(id);
            if (artistTodelete == null)
                return NotFound();
            await _service.Delete(id);
            return NoContent();
        }

    }
}
