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
    public class UsuarioTarjetaController : ControllerBase
    {
        private readonly IUsuarioTarjetaService _service;
        public UsuarioTarjetaController(IUsuarioTarjetaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{userid:int}, {tarjetaid:int}")]
        public async Task<ResponseDto<UsuarioTarjetaDto>> Get(int userid, int tarjetaid)
        {
            return await _service.Get(userid, tarjetaid);
        }

        [HttpPost]
        public async Task Create([FromBody] UsuarioTarjetaDto request)
        {
            await _service.Create(request);

        }

    }
}
