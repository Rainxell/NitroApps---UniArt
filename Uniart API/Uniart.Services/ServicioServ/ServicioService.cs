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
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ServicioDto request)
        {
            try
            {
                await _repository.Create(new Servicio()
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Artista_id = request.Artista_id,
                    Duracion_esperada = request.Duracion_esperada,
                    Precio_base = request.Precio_base,
                    Rating = request.Rating,
                    Q_valoraciones = request.Q_valoraciones,
                    Es_virtual = request.Es_virtual,
                    Porc_adelanto = request.Porc_adelanto,
                    acepta_rembolso = request.acepta_rembolso,
                    Acerca_servicio = request.Acerca_servicio,
                    Q_reviciones = request.Q_reviciones,
                    url_imagen = request.url_imagen,
                   

                 });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ResponseDto<ServicioDto>> Get(int id)
        {
            var response = new ResponseDto<ServicioDto>();
            var request = await _repository.Get(id);

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ServicioDto
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Artista_id = request.Artista_id,
                Duracion_esperada = request.Duracion_esperada,
                Precio_base = request.Precio_base,
                Rating = request.Rating,
                Q_valoraciones = request.Q_valoraciones,
                Es_virtual = request.Es_virtual,
                Porc_adelanto = request.Porc_adelanto,
                acepta_rembolso = request.acepta_rembolso,
                Acerca_servicio = request.Acerca_servicio,
                Q_reviciones = request.Q_reviciones,
                url_imagen = request.url_imagen,
              
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<ServicioDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new ServicioDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Artista_id = request.Artista_id,
                    Duracion_esperada = request.Duracion_esperada,
                    Precio_base = request.Precio_base,
                    Rating = request.Rating,
                    Q_valoraciones = request.Q_valoraciones,
                    Es_virtual = request.Es_virtual,
                    Porc_adelanto = request.Porc_adelanto,
                    acepta_rembolso = request.acepta_rembolso,
                    Acerca_servicio = request.Acerca_servicio,
                    Q_reviciones = request.Q_reviciones,
                    url_imagen = request.url_imagen,
                    
                })
                .ToList();
        }

        public async Task Update(ServicioDto request)
        {
            await _repository.Update(new Servicio
            {

                Id = request.Id,
                Nombre = request.Nombre,
                Artista_id = request.Artista_id,
                Duracion_esperada = request.Duracion_esperada,
                Precio_base = request.Precio_base,
                Rating = request.Rating,
                Q_valoraciones = request.Q_valoraciones,
                Es_virtual = request.Es_virtual,
                Porc_adelanto = request.Porc_adelanto,
                acepta_rembolso = request.acepta_rembolso,
                Acerca_servicio = request.Acerca_servicio,
                Q_reviciones = request.Q_reviciones,
                url_imagen = request.url_imagen,
                

            });
        }

        public async Task<ICollection<ServicioDto>> GetServxArtista(int filter) {
            var collection = await _repository.GetServxArtista(filter);
            return collection.
                Select(request => new ServicioDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Artista_id = request.Artista_id,
                    Duracion_esperada = request.Duracion_esperada,
                    Precio_base = request.Precio_base,
                    Rating = request.Rating,
                    Q_valoraciones = request.Q_valoraciones,
                    Es_virtual = request.Es_virtual,
                    Porc_adelanto = request.Porc_adelanto,
                    acepta_rembolso = request.acepta_rembolso,
                    Acerca_servicio = request.Acerca_servicio,
                    Q_reviciones = request.Q_reviciones,
                    url_imagen = request.url_imagen,
                    
                })
                .ToList();


        }
    }
}
