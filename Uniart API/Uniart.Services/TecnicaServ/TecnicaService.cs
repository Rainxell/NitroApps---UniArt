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
    public class TecnicaService:ITecnicaService
    {
        private readonly ITecnicaRepository _repository;

        public TecnicaService(ITecnicaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(TecnicaDto request)
        {
            try
            {
                await _repository.Create(new Tecnica()
                {
                    Id = request.Id,
                    Nombre = request.Nombre
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

        public async Task<ResponseDto<TecnicaDto>> Get(int id)
        {
            var response = new ResponseDto<TecnicaDto>();
            var tecnica = await _repository.Get(id);

            if (tecnica == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new TecnicaDto
            {
                Id = tecnica.Id,
               Nombre=tecnica.Nombre
            };
            return response;
        }

        public async Task<ICollection<TecnicaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new TecnicaDto
                {
                    Id = request.Id,
                    Nombre=request.Nombre
                })
                .ToList();
        }

        public async Task Update(TecnicaDto request)
        {
            await _repository.Update(new Tecnica
            {

                Id = request.Id,
                Nombre=request.Nombre

            });
        }

    }
}
