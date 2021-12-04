using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;
using Uniart.Entities;
using Uniart.Entities.identity;
using Uniart.Services;

namespace UniArt.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
{
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
            

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<UsuarioDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ResponseDto<UsuarioDto>> Get(int id)
        {
            return await _service.GetUsuario(id);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task Create([FromBody] UsuarioDto request)
        //{
        //    await _service.Create(request);
        //}

        //[HttpPut]
        //[AllowAnonymous]
        //public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody] UsuarioDto request)
        //{
        //    if (id != request.Id)
        //        return BadRequest();

        //    await _service.Update(id , request);
        //    return NoContent();
        //}

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioDto>> Delete(int id)
        {
            var userToDelete = await _service.GetUsuario(id);
            if (userToDelete == null)
                return NotFound();
            await _service.Delete(id);
            return NoContent();
        }

    //    [HttpPost("register")]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> Create(UsuarioDto model)
    //    {
    //        var result = await _userManager.CreateAsync(new Usuario
    //        {
    //            Nombre = model.nombre,
    //            Apellido = model.apellido,
    //            Email = model.email,
    //            UserName = model.nombre_usuario,
    //            Ciudad_id = model.ciudad_id,
    //            Fecha_registro = model.fecha_registro,
    //            Url_foto_perfil = model.url_foto_perfil,
              
                
    //        }, model.password);
    //        if (!result.Succeeded)
    //            throw new Exception("No se pudo crear el usuario");
    //        return Ok();
    //    }

    //    [AllowAnonymous]
    //    [HttpPost("login")]
    //    public async Task<IActionResult> Login(UsuarioDto model)
    //    {
    //        var user = await _userManager.FindByNameAsync(model.nombre_usuario);

    //        var check = await _signInManager.CheckPasswordSignInAsync(user, model.password, false);

    //        if (check.Succeeded)
    //        {
    //            return Ok(
    //                await GenerateToken(user)
    //            );
    //        }

    //        else
    //        {
    //            return BadRequest("Acceso no valido al sistem");
    //        }
    //    }
    //    private async Task<string> GenerateToken(Usuario user)
    //    {
    //        var secretKey = _configuration.GetValue<string>("SecretKey");
    //        var key = Encoding.ASCII.GetBytes(secretKey);

    //        var claims = new List<Claim>()
    //        {
    //            //new Claim(ClaimTypes.NameIdentifier, user.Id),
    //            //new Claim(ClaimTypes.Email, user.Email),
    //            //new Claim(ClaimTypes.Name, user.FirstName),
    //            //new Claim(ClaimTypes.Surname, user.LastName)
    //            //new Claim(ClaimTypes.Name, user.UserName),
    //        };

    //        var roles = await _userManager.GetRolesAsync(user);

    //        foreach (var role in roles)
    //        {
    //            claims.Add(
    //                new Claim(ClaimTypes.Role, role)
    //            );
    //        }

    //        var tokenDescriptor = new SecurityTokenDescriptor()
    //        {
    //            Subject = new ClaimsIdentity(claims),
    //            Expires = DateTime.UtcNow.AddDays(1),
    //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //        };

    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

    //        return tokenHandler.WriteToken(createdToken);
    //    }
    }
}

