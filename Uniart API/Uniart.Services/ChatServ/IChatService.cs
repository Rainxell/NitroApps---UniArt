using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;


namespace Uniart.Services
{
    public interface IChatService
    {
        Task<ResponseDto<ChatDto>> GetArtista(int id);
        Task Create(ChatDto request);
        
    }
}
