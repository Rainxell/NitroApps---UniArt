using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IServicioService
    {
        Task<ICollection<ServicioDto>> GetCollection(string filter);
        Task<ResponseDto<ServicioDto>> Get(int id);
        Task Create(ServicioDto request);
        Task Update(ServicioDto request);
        Task Delete(int id);
    }
}
