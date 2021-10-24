using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IEstiloService
    {
        Task<ICollection<EstiloDto>> GetCollection(string filter);
        Task<ResponseDto<EstiloDto>> Get(int id);
        Task Create(EstiloDto request);
        Task Update(EstiloDto request);
        Task Delete(int id);
    }
}
