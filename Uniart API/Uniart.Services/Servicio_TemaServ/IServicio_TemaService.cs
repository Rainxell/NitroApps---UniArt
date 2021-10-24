using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IServicio_TemaService
    {
        Task<ResponseDto<Servicio_TemaDto>> Get(int id1, int id2);
        Task Create(Servicio_TemaDto request);
    }
}
