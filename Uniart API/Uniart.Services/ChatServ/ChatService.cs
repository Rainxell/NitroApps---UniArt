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
    public class ChatService: IChatService
    {
        private readonly IChatRepository _repository;

        public ChatService(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<ChatDto>> GetArtista(int id)
        {
            var response = new ResponseDto<ChatDto>();
            var artista = await _repository.GetChat(id);

            if (artista == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ChatDto
            {
                Id = artista.Id,
                
            };

            response.Success = true;

            return response;
        }

        public async Task Create(ChatDto request)
        {
            try
            {
                await _repository.Create(new Chat()
                {
                    Id = request.Id,
                    

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
