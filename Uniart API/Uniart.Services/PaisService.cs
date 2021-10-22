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
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _repository;
        public PaisService(IPaisRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<PaisDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new PaisDto
                {
                    Id = p.Id,
                   Nombre = p.Nombre
                })
                .ToList();

        }

        public async Task<ResponseDto<PaisDto>> GetPais(int id)
        {
            var response = new ResponseDto<PaisDto>();
            var pais = await _repository.GetPais(id);

            if (pais == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new PaisDto
            {
                Id = pais.Id,
                Nombre = pais.Nombre
            };

            response.Success = true;

            return response;
        }

        public async Task Create(PaisDto request)
        {
            try
            {
                await _repository.Create(new Pais
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

        public async Task Update(int id, PaisDto request)
        {
            await _repository.Update(new Pais
            {
               Id = request.Id,
               Nombre = request.Nombre

            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
