using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;
using Uniart.Entities.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Uniart.Entities;
using Uniart.Services;
using System.Security.Principal;
using System.Linq;

namespace Uniart.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IArtistaService _serviceA;
        private readonly IUsuarioService _serviceU;



        public IdentityController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, IArtistaService serviceA, IUsuarioService serviceU
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _serviceA = serviceA;
            _serviceU = serviceU;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(ApplicationUserRegisterDto model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Ciudad_id = model.Ciudad_id,
                Url_foto_perfil = model.Url_foto_perfil,
                Fecha_registro = model.Fecha_registro,
                esArtista = model.esArtista,
                Descripcion = model.Descripcion,
                Url_foto_portada = model.Url_foto_portada,
                Rating = model.Rating,
                Q_valoraciones = model.Q_valoraciones

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (model.esArtista == true)
                {
                    await _serviceA.Create(new ArtistaDto { Id = user.Id });
                    return Ok();
                }
                else
                {
                    await _serviceU.Create(new UsuarioDto { Id = user.Id });
                    return Ok();
                }

            }
            throw new Exception("No se pudo crear el usuario");
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(ApplicationUserLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (check.Succeeded)
            {
                return Ok(
                    await GenerateToken(user)
                );
            }

            else
            {
                return BadRequest("Acceso no valido al sistem");
            }
        }

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>()
            {
                //new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.Name, user.FirstName),
                //new Claim(ClaimTypes.Surname, user.LastName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role)
                );
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }

        [AllowAnonymous]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {

                return BadRequest($"User with Id = {id} cannot be found");
            }
            else
            {
                if (user.esArtista == true)
                {

                    await _serviceA.Delete(Int32.Parse(id));
                }
                else
                    await _serviceU.Delete(Int32.Parse(id));

                var result = await _userManager.DeleteAsync(user);
            }
            return Ok();
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<ApplicationUser> ListUsers()
        {

            return _userManager.Users;
        }

        // identity/get/id
        [HttpGet("get/{id:int}")]
        [AllowAnonymous]
        public async Task<ApplicationUser> GetId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
        [AllowAnonymous]
        [HttpGet("artistas")]
        public IEnumerable<ApplicationUser> GetAll()
        {

            return _userManager.Users.Where(x => x.esArtista.Equals(true));


        }
        [AllowAnonymous]
        [HttpGet("usuarios")]
        public IEnumerable<ApplicationUser> GetAllusers()
        {

            return _userManager.Users.Where(x => x.esArtista.Equals(false));


        }
        [AllowAnonymous]
        [HttpGet("nombreartista/username")]
        public IEnumerable<ApplicationUser> GetNombre(string username)
        {

            return _userManager.Users.Where(x => x.UserName.Equals(username));


        }
        [AllowAnonymous]
        [HttpPut("put")]
        public async Task<ActionResult<ApplicationUser>> Put(string id, [FromBody] ApplicationUserRegisterDto request)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {

                throw new Exception("No se pudo crear el usuario");
            }
            else
            {
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.Nombre = request.Nombre;
                user.Apellido = request.Apellido;
                user.Ciudad_id = request.Ciudad_id;
                user.Url_foto_perfil = request.Url_foto_perfil;
                user.Descripcion = request.Descripcion;
                user.Url_foto_portada = request.Url_foto_portada;
                user.Rating = request.Rating;
                user.Q_valoraciones = request.Q_valoraciones;
                

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                    return Ok();
                }
                else
                    throw new Exception("No se pudo actualizar el usuario");
            }




        }


    }

}