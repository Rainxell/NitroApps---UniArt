using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IRed_SocialService
    {
        Task<ICollection<Red_SocialDto>> GetCollection(string filter);
        Task<ResponseDto<Red_SocialDto>> GetRedes(int id);
        Task Create(Red_SocialDto request);
        Task Update(Red_SocialDto request);
        Task Delete(int id);
    }
}
