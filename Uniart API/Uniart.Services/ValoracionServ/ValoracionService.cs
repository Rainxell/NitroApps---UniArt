using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class ValoracionService: IValoracionServices
    {
        private readonly IValoracionRepository _repository;

        public ValoracionService(IValoracionRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ValoracionDto request)
        {
            try
            {
                await _repository.Create(new Valoracion()
                {
                    Usuario_id = request.Usuario_id,
                    Review_id = request.Review_id,
                    Es_like = request.Es_like
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int userid, int reviewid)
        {
            await _repository.Delete(userid,reviewid);
        }

        public async Task<ResponseDto<ValoracionDto>> Get(int userid, int reviewid)
        {
            var response = new ResponseDto<ValoracionDto>();
            var valoracion = await _repository.Get(userid, reviewid);

            if (valoracion == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ValoracionDto
            {
                Usuario_id = valoracion.Usuario_id,
                Review_id = valoracion.Review_id,
                Es_like = valoracion.Es_like
            };

            response.Success = true;

            return response;
        }
    }
}
