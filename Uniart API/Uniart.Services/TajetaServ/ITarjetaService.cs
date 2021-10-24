using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ITarjetaService
    {
        Task<ICollection<TarjetaDto>> GetCollection(string filter);
        Task<ResponseDto<TarjetaDto>> Get(int id);
        Task Create(TarjetaDto request);
        Task Update(TarjetaDto request);
        Task Delete(int id);
    }
}
