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
    public class Red_Social_ArtistaController : ControllerBase
    {
        private readonly IRed_Social_ArtistaService _service;
        public Red_Social_ArtistaController(IRed_Social_ArtistaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Red_Social_ArtistaDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{idredsocial:int},{idartista}")]
        public async Task<ResponseDto<Red_Social_ArtistaDto>> Get(int idredsocial, int idartista)
        {
            return await _service.Get(idredsocial, idartista);
        }

        [HttpPost]
        public async Task Create([FromBody] Red_Social_ArtistaDto request)
        {
            await _service.Create(request);

        }

       
        

    }
}
