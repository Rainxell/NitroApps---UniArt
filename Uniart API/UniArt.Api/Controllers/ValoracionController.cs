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
    public class ValoracionController : ControllerBase
    {
        private readonly IValoracionServices _service;
        public ValoracionController(IValoracionServices service)
        {
            _service = service;
        }
       
        [HttpGet]
        [Route("{userid:int}, {reviewid:int}")]
        public async Task<ResponseDto<ValoracionDto>> Get(int userid, int reviewid)
        {
            return await _service.Get(userid, reviewid);
        }

        [HttpPost]
        public async Task Create([FromBody] ValoracionDto request)
        {
            await _service.Create(request);

        }

        [HttpDelete("{userid:int}, {reviewid:int}")]
        public async Task<ActionResult<ValoracionDto>> Delete(int userid, int reviewid)
        {
            var artistTodelete = _service.Get(userid, reviewid);
            if (artistTodelete == null)
                return NotFound();
            await _service.Delete(userid, reviewid);
            return NoContent();
        }

    }
}
