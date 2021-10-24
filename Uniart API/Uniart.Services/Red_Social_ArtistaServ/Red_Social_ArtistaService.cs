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
    public class Red_Social_ArtistaService: IRed_Social_ArtistaService
    {
        private readonly IRed_Social_ArtistaRepository _repository;

        public Red_Social_ArtistaService(IRed_Social_ArtistaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Red_Social_ArtistaDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new Red_Social_ArtistaDto
                {
                    Red_social_id = request.Red_social_id,
                    Artista_id = request.Artista_id,
                    username = request.username,
                })
                .ToList();

        }

        public async Task<ResponseDto<Red_Social_ArtistaDto>> Get(int id, int id2)
        {
            var response = new ResponseDto<Red_Social_ArtistaDto>();
            var request = await _repository.Get(id, id2);

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Red_Social_ArtistaDto
            {
                Red_social_id = request.Red_social_id,
                Artista_id = request.Artista_id,
                username = request.username,
            };

            response.Success = true;

            return response;
        }

        public async Task Create(Red_Social_ArtistaDto request)
        {
            try
            {
                await _repository.Create(new Red_Social_Artista()
                {
                    Red_social_id = request.Red_social_id,
                    Artista_id = request.Artista_id,
                    username = request.username,

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(Red_Social_ArtistaDto request)
        {
            await _repository.Update(new Red_Social_Artista
            {

                Red_social_id = request.Red_social_id,
                Artista_id = request.Artista_id,
                username = request.username,

            });
        }

        public async Task Delete(int id, int id2)
        {
            await _repository.Delete(id,id2);
        }
    }
}
