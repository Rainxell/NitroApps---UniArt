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
    public class Servicio_CaracteristicaService: IServicio_CaracteristicaService
    {
        private readonly IServicio_CaracteristicaRepository _repository;

        public Servicio_CaracteristicaService(IServicio_CaracteristicaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Servicio_CaracteristicaDto request)
        {
            try
            {
                await _repository.Create(new Servicio_Caracteristica()
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

        public async Task<ResponseDto<Servicio_CaracteristicaDto>> Get(int id)
        {
            var response = new ResponseDto<Servicio_CaracteristicaDto>();
            var entidad = await _repository.Get(id);

            if (entidad == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Servicio_CaracteristicaDto
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<Servicio_CaracteristicaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new Servicio_CaracteristicaDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre
                })
                .ToList();
        }

        public async Task Update(Servicio_CaracteristicaDto request)
        {
            await _repository.Update(new Servicio_Caracteristica
            {

                Id = request.Id,
                Nombre = request.Nombre

            });
        }
    }
}
