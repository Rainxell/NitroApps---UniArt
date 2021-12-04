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
    public class ChatController: ControllerBase
    {
        private readonly IChatService _service;
        public ChatController(IChatService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public async Task<ResponseDto<ChatDto>> Get(int id)
        {
            return await _service.GetArtista(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] ChatDto request)
        {
            await _service.Create(request);

        }

        
    }
}
