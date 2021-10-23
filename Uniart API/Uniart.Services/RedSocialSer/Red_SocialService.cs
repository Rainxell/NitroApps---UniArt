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
    public class Red_SocialService : IRed_SocialService
    {
        private readonly IRed_SocialRepository _repository;

        public Red_SocialService(IRed_SocialRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Red_SocialDto request)
        {
            try
            {
                await _repository.Create(new Red_Social()
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Link = request.Link

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

        public async Task<ICollection<Red_SocialDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new Red_SocialDto
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Link = request.Link
                })
                .ToList();
        }

        public async Task<ResponseDto<Red_SocialDto>> GetRedes(int id)
        {
            var response = new ResponseDto<Red_SocialDto>();
            var red = await _repository.GetRedes(id);

            if (red == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Red_SocialDto
            {
                Id = red.Id,
                Nombre = red.Nombre,
                Link = red.Link
            };

            response.Success = true;

            return response;
        }

        public async Task Update(Red_SocialDto request)
        {
            await _repository.Update(new Red_Social
            {

                Id = request.Id,
                Nombre = request.Nombre,
                Link = request.Link

            });
        }
    }
}
