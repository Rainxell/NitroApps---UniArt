using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IServicio_VariacionService
    {
        Task<ICollection<Servicio_VariacionDto>> GetCollection(string filter);
        Task<ResponseDto<Servicio_VariacionDto>> Get(int id);
        Task Create(Servicio_VariacionDto request);
        Task Update(Servicio_VariacionDto request);
        Task Delete(int id);
    }
}
