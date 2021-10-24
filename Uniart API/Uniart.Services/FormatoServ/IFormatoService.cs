using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IFormatoService
    {
        Task<ICollection<FormatoDto>> GetCollection(string filter);
        Task<ResponseDto<FormatoDto>> Get(int id);
        Task Create(FormatoDto request);
        Task Update(FormatoDto request);
        Task Delete(int id);
    }
}
