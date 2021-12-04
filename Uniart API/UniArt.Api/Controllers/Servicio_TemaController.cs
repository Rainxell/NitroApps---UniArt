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
    public class Servicio_TemaController : ControllerBase
    {
        private readonly IServicio_TemaService _service;
        public Servicio_TemaController(IServicio_TemaService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{servicioid:int}, {temaid:int}")]
        public async Task<ResponseDto<Servicio_TemaDto>> Get(int servicioid, int temaid)
        {
            return await _service.Get(servicioid, temaid);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] Servicio_TemaDto request)
        {
            await _service.Create(request);

        }

    }
}
