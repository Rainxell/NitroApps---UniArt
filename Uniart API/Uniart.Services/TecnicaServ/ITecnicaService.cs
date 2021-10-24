using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ITecnicaService
    {
        Task<ICollection<TecnicaDto>> GetCollection(string filter);
        Task<ResponseDto<TecnicaDto>> Get(int id);
        Task Create(TecnicaDto request);
        Task Update(TecnicaDto request);
        Task Delete(int id);
    }
}
