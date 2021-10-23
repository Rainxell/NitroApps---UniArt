using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services.Variacion_DetalleServ
{
    public class Variacion_DetalleService : IVariacion_DetalleService
    {
        private readonly IVariacion_DetalleRepository _repository;

        public Variacion_DetalleService(IVariacion_DetalleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<Variacion_DetalleDto>> Get(int SV_id, int CO_id)
        {
            var response = new ResponseDto<Variacion_DetalleDto>();
            var vd = await _repository.Get(SV_id, CO_id);

            if (vd == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Variacion_DetalleDto
            {
                Servicio_Variacion_id = vd.Servicio_Variacion_id,
                Caracteristica_Opciones_id = vd.Caracteristica_Opciones_id
            };

            response.Success = true;

            return response;
        }

        public async Task Create(Variacion_DetalleDto request)
        {
            try
            {
                await _repository.Create(new Variacion_Detalle()
                {
                    Servicio_Variacion_id = request.Servicio_Variacion_id,
                    Caracteristica_Opciones_id = request.Caracteristica_Opciones_id

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Update(Variacion_DetalleDto request)
        {
            await _repository.Update(new Variacion_Detalle
            {

                Servicio_Variacion_id = request.Servicio_Variacion_id,
                Caracteristica_Opciones_id = request.Caracteristica_Opciones_id

            });
        }
       

        
    }
}
