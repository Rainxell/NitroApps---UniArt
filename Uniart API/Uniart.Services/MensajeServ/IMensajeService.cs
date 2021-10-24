using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IMensajeService
    {
        Task<ICollection<MensajeDto>> GetCollection(string filter);
        Task<ResponseDto<MensajeDto>> Get(int id);
        Task Create(MensajeDto request);
        Task Update(MensajeDto request);
        Task Delete(int id);
    }
}
