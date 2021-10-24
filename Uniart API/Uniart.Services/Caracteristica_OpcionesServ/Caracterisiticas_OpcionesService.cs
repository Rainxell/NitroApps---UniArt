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
    public class Caracterisiticas_OpcionesService: ICaracteristicas_OpcionesService
    {
        private readonly ICaracteristica_OptionRepository _repository;

        public Caracterisiticas_OpcionesService(ICaracteristica_OptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Caracteristica_OpcionesDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new Caracteristica_OpcionesDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre
                    
                })
                .ToList();

        }

        public async Task<ResponseDto<Caracteristica_OpcionesDto>> Get(int id)
        {
            var response = new ResponseDto<Caracteristica_OpcionesDto>();
            var artista = await _repository.GetCaracteristica_Option(id);

            if (artista == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Caracteristica_OpcionesDto
            {
                Id = artista.Id,
                Nombre = artista.Nombre

            };

            response.Success = true;

            return response;
        }

        public async Task Create(Caracteristica_OpcionesDto request)
        {
            try
            {
                await _repository.Create(new Caracteristica_Opciones()
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

        public async Task Update(Caracteristica_OpcionesDto request)
        {
            await _repository.Update(new Caracteristica_Opciones
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
