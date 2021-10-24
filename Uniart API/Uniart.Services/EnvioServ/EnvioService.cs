using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess.EnvioRepos;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class EnvioService :IEnvioService
    {
        private readonly IEnvioRepository _repository;

        public EnvioService(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(EnvioDto request)
        {
            try
            {
                await _repository.Create(new Envio()
                {
                    Id = request.Id,
                    Url_imagen_enviada = request.Url_imagen_enviada,
                    Descripcion = request.Descripcion

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

        public async Task<ResponseDto<EnvioDto>> Get(int id)
        {
            var response = new ResponseDto<EnvioDto>();
            var request = await _repository.GetEnvio(id);

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new EnvioDto
            {
                Id = request.Id,
                Url_imagen_enviada = request.Url_imagen_enviada,
                Descripcion = request.Descripcion
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<EnvioDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new EnvioDto
                {
                    Id = request.Id,
                   Url_imagen_enviada = request.Url_imagen_enviada,
                   Descripcion =request.Descripcion
                })
                .ToList();
        }

        public async Task Update(EnvioDto request)
        {
            await _repository.Update(new Envio
            {

                Id = request.Id,
                Url_imagen_enviada = request.Url_imagen_enviada,
                Descripcion = request.Descripcion

            });
        }
    }
}
