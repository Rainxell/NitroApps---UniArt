using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ICiudadService
    {
        Task<ICollection<CiudadDto>> GetCollection(string filter);
        Task<ResponseDto<CiudadDto>> GetCiudad(int id);

        Task Create(CiudadDto request);

        Task Update(int id, CiudadDto request);

        Task Delete(int id);
    }
}
