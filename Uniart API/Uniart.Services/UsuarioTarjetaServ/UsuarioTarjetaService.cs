using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class UsuarioTarjetaService:IUsuarioTarjetaService
    {
        private readonly IUsuarioTarjetaRepository _repository;

        public UsuarioTarjetaService(IUsuarioTarjetaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(UsuarioTarjetaDto request)
        {
            try
            {
                await _repository.Create(new Usuario_Tarjeta()
                {
                    Usuario_id = request.Usuario_id,
                    Tarjeta_id = request.Tarjeta_id
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ResponseDto<UsuarioTarjetaDto>> Get(int userid, int tarjetaid)
        {
            var response = new ResponseDto<UsuarioTarjetaDto>();
            var valoracion = await _repository.Get(userid, tarjetaid);

            if (valoracion == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new UsuarioTarjetaDto
            {
                Usuario_id = valoracion.Usuario_id,
                Tarjeta_id = valoracion.Tarjeta_id,
                
            };

            response.Success = true;

            return response;
        }

        
    }
}
