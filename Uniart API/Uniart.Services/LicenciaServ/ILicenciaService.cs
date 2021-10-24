using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ILicenciaService
    {
        Task<ICollection<LicenciaDto>> GetCollection(string filter);
        Task<ResponseDto<LicenciaDto>> Get(int id);
        Task Create(LicenciaDto request);
        Task Update(LicenciaDto request);
        Task Delete(int id);
    }
}
