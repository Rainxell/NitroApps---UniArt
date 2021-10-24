using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IComisionService
    {
        Task<ResponseDto<ComisionDto>> Get(int id);
        Task Create(ComisionDto request);
        Task Update(ComisionDto request);
        Task Delete(int id);
    }
}
