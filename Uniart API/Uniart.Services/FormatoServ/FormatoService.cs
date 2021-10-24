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
    public class FormatoService:IFormatoService
    {
        private readonly IFormatoRepository _repository;

        public FormatoService(IFormatoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(FormatoDto request)
        {
            try
            {
                await _repository.Create(new Formato()
                {
                    Id = request.Id,
                    Nombre = request.Nombre

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

        public async Task<ResponseDto<FormatoDto>> Get(int id)
        {
            var response = new ResponseDto<FormatoDto>();
            var formato = await _repository.Get(id);

            if (formato == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new FormatoDto
            {
                Id = formato.Id,
                Nombre = formato.Nombre
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<FormatoDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new FormatoDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre
                })
                .ToList();
        }

        public async Task Update(FormatoDto request)
        {
            await _repository.Update(new Formato
            {

                Id = request.Id,
                Nombre = request.Nombre

            });
        }
    }
}
