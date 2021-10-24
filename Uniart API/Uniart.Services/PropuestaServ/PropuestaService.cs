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
    public class PropuestaService : IPropuestaService
    {
        private readonly IPropuestaRepository _repository;

        public PropuestaService(IPropuestaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(PropuestaDto request)
        {
            try
            {
                await _repository.Create(new Propuesta()
                {
                    Id = request.Id,
                    Descripcion = request.Descripcion,
                    Fecha = request.Fecha

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

        public async Task<ResponseDto<PropuestaDto>> Get(int id)
        {
            var response = new ResponseDto<PropuestaDto>();
            var propuesta = await _repository.Get(id);

            if (propuesta == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new PropuestaDto
            {
                Id = propuesta.Id,
                Descripcion = propuesta.Descripcion,
                Fecha = propuesta.Fecha
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<PropuestaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new PropuestaDto
                {
                    Id = request.Id,
                    Descripcion = request.Descripcion,
                    Fecha = request.Fecha
                })
                .ToList();
        }

        public async Task Update(PropuestaDto request)
        {
            await _repository.Update(new Propuesta
            {

                Id = request.Id,
                Descripcion = request.Descripcion,
                Fecha = request.Fecha

            });
        }
    }
}
