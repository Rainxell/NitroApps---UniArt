using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ICaracteristicas_OpcionesService
    {
        Task<ICollection<Caracteristica_OpcionesDto>> GetCollection(string filter);
        Task<ResponseDto<Caracteristica_OpcionesDto>> Get(int id);
        Task Create(Caracteristica_OpcionesDto request);
        Task Update(Caracteristica_OpcionesDto request);
        Task Delete(int id);
    }
}
