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
                Select(p => new ArtistaDto
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    Url_foto_portada = p.Url_foto_portada,
                    Rating =p.Rating,
                    Q_valoraciones =p.Q_valoraciones
                })
                .ToList();

        }

        public async Task<ResponseDto<ArtistaDto>> GetArtista(int id)
        {
            var response = new ResponseDto<ArtistaDto>();
            var artista = await _repository.GetArtista(id);

            if (artista == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ArtistaDto
            {
                Id = artista.Id,
                Descripcion = artista.Descripcion,
                Url_foto_portada = artista.Url_foto_portada,
                Rating = artista.Rating,
                Q_valoraciones = artista.Q_valoraciones
            };

            response.Success = true;

            return response;
        }

        public async Task Create(ArtistaDto request)
        {
            try
            {
                await _repository.Create(new Artista
                {
                    Id = request.Id,
                    Descripcion = request.Descripcion,
                    Url_foto_portada = request.Url_foto_portada,
                    Rating = request.Rating,
                    Q_valoraciones = request.Q_valoraciones

                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Update(ArtistaDto request)
        {
            await _repository.Update( new Artista {
                Descripcion = request.Descripcion,
                Url_foto_portada = request.Url_foto_portada,
                Rating = request.Rating,
                Q_valoraciones = request.Q_valoraciones

            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

    }
}
