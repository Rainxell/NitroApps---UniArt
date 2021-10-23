using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IPaisService
    {
        Task<ICollection<PaisDto>> GetCollection(string filter);
        Task<ResponseDto<PaisDto>> GetPais(int id);

        Task Create(PaisDto request);

        Task Update(int id, PaisDto request);

        Task Delete(int id);
    }
}
