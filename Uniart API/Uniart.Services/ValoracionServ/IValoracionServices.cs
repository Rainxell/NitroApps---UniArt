using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IValoracionServices
    {
        Task<ResponseDto<ValoracionDto>> Get(int userid, int reviewid);
        Task Create(ValoracionDto request);
        Task Delete(int userid, int reviewid);
    }
}
