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
    public class MensajeService:IMensajeService
    {
        private readonly IMensajeRepository _repository;

        public MensajeService(IMensajeRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(MensajeDto request)
        {
            try
            {
                await _repository.Create(new Mensaje()
                {
                    Id = request.Id,
                    Hora_mensaje = request.Hora_mensaje,
                    Texto_mensaje = request.Texto_mensaje

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

        public async Task<ResponseDto<MensajeDto>> Get(int id)
        {
            var response = new ResponseDto<MensajeDto>();
            var mensaje = await _repository.Get(id);

            if (mensaje == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new MensajeDto
            {
                Id = mensaje.Id,
                Hora_mensaje = mensaje.Hora_mensaje,
                Texto_mensaje = mensaje.Texto_mensaje
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<MensajeDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new MensajeDto
                {
                    Id = request.Id,
                    Hora_mensaje = request.Hora_mensaje,
                    Texto_mensaje = request.Texto_mensaje
                })
                .ToList();
        }

        public async Task Update(MensajeDto request)
        {
            await _repository.Update(new Mensaje
            {

                Id = request.Id,
                Hora_mensaje = request.Hora_mensaje,
                Texto_mensaje = request.Texto_mensaje

            });
        }
    }
}
