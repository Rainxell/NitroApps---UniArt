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
    public class CiudadService: ICiudadService
    {
        private readonly ICiudadRepository _repository;

        public CiudadService(ICiudadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<CiudadDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new CiudadDto
                {
                    Id = p.Id,
                    Nombre =p.Nombre,
                    Pais_id = p.Pais_id,
                })
                .ToList();

        }

        public async Task<ResponseDto<CiudadDto>> GetCiudad(int id)
        {
            var response = new ResponseDto<CiudadDto>();
            var ciudad = await _repository.GetCiudad(id);

            if (ciudad == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new CiudadDto
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                Pais_id = ciudad.Pais_id,
            };

            response.Success = true;

            return response;
        }

        public async Task Create(CiudadDto request)
        {
            try
            {
                await _repository.Create(new Ciudad
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Pais_id = request.Pais_id,

                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Update(int id, CiudadDto request)
        {
            await _repository.Update(new Ciudad
            {
                Id = request.Id,
                Nombre =request.Nombre,
                Pais_id = request.Pais_id,
            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
