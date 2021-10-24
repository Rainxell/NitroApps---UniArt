using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess.Envio_Servicio_CiudadRepos;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    class Envio_Servicio_CiudadService:IEnvio_Servicio_CiudadService
    {
        private readonly IEnvio_Servicio_CiudadRepository _repository;

        public Envio_Servicio_CiudadService(IEnvio_Servicio_CiudadRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Envio_Servicio_CiudadDto request)
        {
            try
            {
                await _repository.Create(new Envio_Servicio_Ciudad()
                {
                    Servicio_id = request.Servicio_id,
                    Ciudad_id = request.Ciudad_id,
                    Costo_envio = request.Costo_envio,

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ResponseDto<Envio_Servicio_CiudadDto>> Get(int id, int id2)
        {
            var response = new ResponseDto<Envio_Servicio_CiudadDto>();
            var request = await _repository.Get(id, id2);

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Envio_Servicio_CiudadDto
            {
                Servicio_id = request.Servicio_id,
                Ciudad_id = request.Ciudad_id,
                Costo_envio = request.Costo_envio,
            };

            response.Success = true;

            return response;
        }

        public async Task Update(Envio_Servicio_CiudadDto request)
        {
            await _repository.Update(new Envio_Servicio_Ciudad
            {

                Servicio_id = request.Servicio_id,
                Ciudad_id = request.Ciudad_id,
                Costo_envio = request.Costo_envio,

            });
        }


    }
}
