using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IEnvioService
    {
        Task<ICollection<EnvioDto>> GetCollection(string filter);
        Task<ResponseDto<EnvioDto>> Get(int id);
        Task Create(EnvioDto request);
        Task Update(EnvioDto request);
        Task Delete(int id);
    }
}
