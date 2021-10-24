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
    public class TemaService:ITemaService
    {
        private readonly ITemaRepository _repository;

        public TemaService(ITemaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(TemaDto request)
        {
            try
            {
                await _repository.Create(new Tema()
                {
                    Id = request.id,
                    Nombre = request.nombre


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

        public async Task<ResponseDto<TemaDto>> Get(int id)
        {
            var response = new ResponseDto<TemaDto>();
            var artista = await _repository.Get(id);

            if (artista == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new TemaDto
            {
                id = artista.Id,
                nombre = artista.Nombre
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<TemaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new TemaDto
                {
                    id = request.Id,
                    nombre = request.Nombre
                })
                .ToList();
        }

        public async Task Update(TemaDto request)
        {
            await _repository.Update(new Tema
            {

                Id = request.id,
                Nombre = request.nombre

            });
        }
    }
}
