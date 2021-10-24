using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IRed_Social_ArtistaService
    {
        Task<ICollection<Red_Social_ArtistaDto>> GetCollection(string filter);
        Task<ResponseDto<Red_Social_ArtistaDto>> Get(int id, int id2);
        Task Create(Red_Social_ArtistaDto request);
        Task Update(Red_Social_ArtistaDto request);
        Task Delete(int id, int id2);
    }
}
