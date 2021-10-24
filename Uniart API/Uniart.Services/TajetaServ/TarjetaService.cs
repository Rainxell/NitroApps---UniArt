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
    public class TarjetaService:ITarjetaService
    {
        private readonly ITarjetaRepository _repository;

        public TarjetaService(ITarjetaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(TarjetaDto request)
        {
            try
            {
                await _repository.Create(new Tarjeta()
                {
                    Id = request.Id,
                    Numero_tarjeta = request.Numero_tarjeta,
                    Nombre_completo = request.Nombre_completo,
                    Fecha_vencimiento = request.Fecha_vencimiento,
                    Cvc = request.Cvc

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

        public async Task<ResponseDto<TarjetaDto>> Get(int id)
        {
            var response = new ResponseDto<TarjetaDto>();
            var tarjeta = await _repository.Get(id);

            if (tarjeta == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new TarjetaDto
            {
                Id = tarjeta.Id,
                Numero_tarjeta = tarjeta.Numero_tarjeta,
                Nombre_completo = tarjeta.Nombre_completo,
                Fecha_vencimiento = tarjeta.Fecha_vencimiento,
                Cvc = tarjeta.Cvc
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<TarjetaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new TarjetaDto
                {
                    Id = request.Id,
                    Numero_tarjeta = request.Numero_tarjeta,
                    Nombre_completo = request.Nombre_completo,
                    Fecha_vencimiento = request.Fecha_vencimiento,
                    Cvc = request.Cvc
                })
                .ToList();
        }

        public async Task Update(TarjetaDto request)
        {
            await _repository.Update(new Tarjeta
            {

                Id = request.Id,
                Numero_tarjeta = request.Numero_tarjeta,
                Nombre_completo = request.Nombre_completo,
                Fecha_vencimiento = request.Fecha_vencimiento,
                Cvc = request.Cvc

            });
        }
    }
}
