using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IServicio_FormatoService
    {
        Task<ResponseDto<Servicio_FormatoDto>> Get(int id, int id2);
        Task Create(Servicio_FormatoDto request);
    }
}
