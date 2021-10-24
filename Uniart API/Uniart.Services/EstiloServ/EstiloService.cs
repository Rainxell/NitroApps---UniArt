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
    public class EstiloService : IEstiloService
    {
        private readonly IEstiloRepository _repository;

        public EstiloService(IEstiloRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(EstiloDto request)
        {
            try
            {
                await _repository.Create(new Estilo()
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

        public async Task<ResponseDto<EstiloDto>> Get(int id)
        {
            var response = new ResponseDto<EstiloDto>();
            var estilo = await _repository.Get(id);

            if (estilo == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new EstiloDto
            {
                Id = estilo.Id,
                Nombre = estilo.Nombre
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<EstiloDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new EstiloDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre
                })
                .ToList();
        }

        public async Task Update(EstiloDto request)
        {
            await _repository.Update(new Estilo
            {

                Id = request.Id,
                Nombre = request.Nombre

            });
        }
    }
}
