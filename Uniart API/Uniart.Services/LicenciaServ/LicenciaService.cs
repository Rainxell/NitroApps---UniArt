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
    public class LicenciaService:ILicenciaService
    {
        private readonly ILicenciaRepository _repository;

        public LicenciaService(ILicenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(LicenciaDto request)
        {
            try
            {
                await _repository.Create(new Licencia()
                {
                    Id = request.Id,
                    Nombre = request.Nombre,

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

        public async Task<ResponseDto<LicenciaDto>> Get(int id)
        {
            var response = new ResponseDto<LicenciaDto>();
            var artista = await _repository.Get(id);

            if (artista == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new LicenciaDto
            {
                Id = artista.Id,
                Nombre = artista.Nombre,
                
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<LicenciaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new LicenciaDto
                {
                    Id = request.Id,
                    Nombre=request.Nombre
                })
                .ToList();
        }

        public async Task Update(LicenciaDto request)
        {
            await _repository.Update(new Licencia
            {

                Id = request.Id,
                Nombre = request.Nombre,

            });
        }
    }
}
