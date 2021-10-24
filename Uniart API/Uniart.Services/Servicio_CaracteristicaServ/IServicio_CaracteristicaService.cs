using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IServicio_CaracteristicaService
    {
        Task<ICollection<Servicio_CaracteristicaDto>> GetCollection(string filter);
        Task<ResponseDto<Servicio_CaracteristicaDto>> Get(int id);
        Task Create(Servicio_CaracteristicaDto request);
        Task Update(Servicio_CaracteristicaDto request);
        Task Delete(int id);
    }
}
