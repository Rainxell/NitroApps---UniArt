using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class Servicio_TemaService:IServicio_TemaService
    {
        private readonly IServicio_TemaRepository _repository;

        public Servicio_TemaService(IServicio_TemaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Servicio_TemaDto request)
        {
            try
            {
                await _repository.Create(new Servicio_Tema()
                {
                    Servicio_id = request.Servicio_id,
                    Tema_id = request.Tema_id

                }) ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ResponseDto<Servicio_TemaDto>> Get(int id1, int id2)
        {
            var response = new ResponseDto<Servicio_TemaDto>();
            var entidad = await _repository.Get(id1,id2);

            if (entidad == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Servicio_TemaDto
            {
                Servicio_id = entidad.Servicio_id,
                Tema_id = entidad.Tema_id
            };

            response.Success = true;

            return response;
        }
    }
}
