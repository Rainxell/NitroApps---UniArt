using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IPropuestaService
    {
        Task<ICollection<PropuestaDto>> GetCollection(string filter);
        Task<ResponseDto<PropuestaDto>> Get(int id);
        Task Create(PropuestaDto request);
        Task Update(PropuestaDto request);
        Task Delete(int id);
    }
}
