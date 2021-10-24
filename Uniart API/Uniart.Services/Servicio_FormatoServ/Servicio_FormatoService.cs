using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class Servicio_FormatoService: IServicio_FormatoService
    {
        private readonly IServicio_FormatoRepository _repository;

        public Servicio_FormatoService(IServicio_FormatoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Servicio_FormatoDto request)
        {
            try
            {
                await _repository.Create(new Servicio_Formato()
                {
                    Servicio_id = request.Servicio_id,
                    Formato_id = request.Formato_id
                    

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ResponseDto<Servicio_FormatoDto>> Get(int id, int id2)
        {
            var response = new ResponseDto<Servicio_FormatoDto>();
            var entidad = await _repository.Get(id, id2);

            if (entidad == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Servicio_FormatoDto
            {
                Servicio_id = entidad.Servicio_id,
                Formato_id = entidad.Formato_id
            };

            response.Success = true;

            return response;
        }

    }
}
