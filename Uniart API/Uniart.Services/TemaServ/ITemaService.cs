using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ITemaService
    {
        Task<ICollection<TemaDto>> GetCollection(string filter);
        Task<ResponseDto<TemaDto>> Get(int id);
        Task Create(TemaDto request);
        Task Update(TemaDto request);
        Task Delete(int id);
    }
}
