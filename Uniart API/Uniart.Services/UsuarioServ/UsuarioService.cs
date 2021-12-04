using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<UsuarioDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new UsuarioDto
                {
                    Id = p.Id,
                    //nombre_usuario = p.Usuario_.UserName,
                    ///password = p.Password,
                    //email = p.Usuario_.Email,
                    //nombre = p.Usuario_.Nombre,
                   // apellido = p.Usuario_.Apellido,
                   // url_foto_perfil = p.Usuario_.Url_foto_perfil,
                   // fecha_registro = p.Usuario_.Fecha_registro,
                    //ciudad_id = p.Usuario_.Ciudad_id
                })
                .ToList();

        }

        public async Task<ResponseDto<UsuarioDto>> GetUsuario(int id)
        {
            var response = new ResponseDto<UsuarioDto>();
            var usuario = await _repository.GetUsuario(id);

            if (usuario == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new UsuarioDto
            {
                Id = usuario.Id,
                //nombre_usuario = usuario.Usuario_.UserName,
               // password = usuario.Password,
                //email = usuario.Usuario_.Email,
                //nombre = usuario.Usuario_.Nombre,
                //apellido = usuario.Usuario_.Apellido,
               // url_foto_perfil = usuario.Usuario_.Url_foto_perfil,
               // fecha_registro = usuario.Usuario_.Fecha_registro,
               // ciudad_id = usuario.Usuario_.Ciudad_id
            };

            response.Success = true;

            return response;
        }

        public async Task Create(UsuarioDto request)
        {
            try
            {
                await _repository.Create(new Usuario
                {
                    Id = request.Id,
        //            UserName = request.nombre_usuario,
        //            //Password = request.password,
        //            Email = request.email,
        //            Nombre = request.nombre,
        //            Apellido = request.apellido,
        //            Url_foto_perfil = request.url_foto_perfil,
        //            Fecha_registro = request.fecha_registro,
        //            Ciudad_id = request.ciudad_id
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public async Task Update(int id, UsuarioDto request)
        //{
        //    await _repository.Update(new Usuario
        //    {
        //        Id = request.Id,
        //        UserName = request.nombre_usuario,
        //        //Password = request.password,
        //        Email = request.email,
        //        Nombre = request.nombre,
        //        Apellido = request.apellido,
        //        Url_foto_perfil = request.url_foto_perfil,
        //        Fecha_registro = request.fecha_registro,
        //        Ciudad_id = request.ciudad_id
        //    });
        //}

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }


    }
}
