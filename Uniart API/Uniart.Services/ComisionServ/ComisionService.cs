using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;
using Uniart.DataAccess.ComisionRepos;
using Uniart.Dto;

namespace Uniart.Services
{
    public class ComisionService: IComisionService
    {
        private readonly IComisionRepository _repository;

        public ComisionService(IComisionRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResponseDto<ComisionDto>> Get(int id)
        {
            var response = new ResponseDto<ComisionDto>();
            var artista = await _repository.GetComision(id);

            if (artista == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ComisionDto
            {
                Id = artista.Id,
                Porc_avance = artista.Porc_avance,
                Monto_pago_inicial = artista.Monto_pago_inicial,
                Monto_pago_final = artista.Monto_pago_final,
                Fecha_inicio = artista.Fecha_inicio,
                Fecha_fin = artista.Fecha_fin,
                Fecha_entrega = artista.Fecha_entrega,
                Servicio_id = artista.Servicio_id,
                Review_Usuario_id = artista.Review_Usuario_id,
                Usuario_id = artista.Usuario_id,
                Servicio_Variacion_id = artista.Servicio_Variacion_id,
                Descripcion = artista.Descripcion

            };

            response.Success = true;

            return response;
        }

        public async Task Create(ComisionDto request)
        {
            try
            {
                await _repository.Create(new Comision()
                {
                    Id = request.Id,
                    Monto_pago_inicial = request.Monto_pago_inicial,
                    Monto_pago_final = request.Monto_pago_final,
                    Fecha_inicio = request.Fecha_inicio,
                    Fecha_fin = request.Fecha_fin,
                    Fecha_entrega = request.Fecha_entrega,
                    Servicio_id = request.Servicio_id,
                    Review_Usuario_id = request.Review_Usuario_id,
                    Usuario_id = request.Usuario_id,
                    Servicio_Variacion_id = request.Servicio_Variacion_id,
                    Descripcion = request.Descripcion
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(ComisionDto request)
        {
            await _repository.Update(new Comision
            {

                Id = request.Id,
                Monto_pago_inicial = request.Monto_pago_inicial,
                Monto_pago_final = request.Monto_pago_final,
                Fecha_inicio = request.Fecha_inicio,
                Fecha_fin = request.Fecha_fin,
                Fecha_entrega = request.Fecha_entrega,
                Servicio_id = request.Servicio_id,
                Review_Usuario_id = request.Review_Usuario_id,
                Usuario_id = request.Usuario_id,
                Servicio_Variacion_id = request.Servicio_Variacion_id,
                Descripcion = request.Descripcion

            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
