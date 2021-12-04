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
    public class ArtistaService: IArtistaService
    {
        private readonly IArtistaRepository _repository;

        public ArtistaService(IArtistaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ArtistaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new ArtistaDto
                {
                    Id = request.Id,
                    //nombre_usuario = request.Artista_.UserName,
                    //password = request.Password,
                    //email = request.Artista_.Email,
                    //nombre = request.Artista_.Nombre,
                    //apellido = request.Artista_.Apellido,
                    //url_foto_perfil = request.Artista_.Url_foto_perfil,
                    //fecha_registro = request.Artista_.Fecha_registro,
                    //Descripcion = request.Artista_.Descripcion,
                    //Url_foto_portada = request.Artista_.Url_foto_portada,
                    //Rating = request.Artista_.Rating,
                    //Q_valoraciones = request.Artista_.Q_valoraciones
                })
                .ToList();

        }

        public async Task<Artista> GetArtista(int id)
        {
            return await _repository.GetArtista(id);
        }

        public async Task Create(ArtistaDto request)
        {
            try
            {                              
                await _repository.Create(new Artista()
                {
                    Id = request.Id,
        //            UserName = request.nombre_usuario,
        //            //Password = request.password,
        //            Email = request.email,
        //            Nombre = request.nombre,
        //            Apellido = request.apellido,
        //            Url_foto_perfil = request.url_foto_perfil,
        //            Fecha_registro = request.fecha_registro,
        //            Descripcion = request.Descripcion,
        //            Url_foto_portada = request.Url_foto_portada,
        //            Rating = request.Rating,
        //            Q_valoraciones = request.Q_valoraciones

                } );
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task Update(ArtistaDto request)
        //{
        //    await _repository.Update( new Artista {

        //        Id = request.Id,
        //        UserName = request.nombre_usuario,
        //        //Password = request.password,
        //        Email = request.email,
        //        Nombre = request.nombre,
        //        Apellido = request.apellido,
        //        Url_foto_perfil = request.url_foto_perfil,
        //        Fecha_registro = request.fecha_registro,
        //        Descripcion = request.Descripcion,
        //        Url_foto_portada = request.Url_foto_portada,
        //        Rating = request.Rating,
        //        Q_valoraciones = request.Q_valoraciones

        //    });
        //}

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

    }
}
