using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IEnvio_Servicio_CiudadService
    {
        Task<ResponseDto<Envio_Servicio_CiudadDto>> Get(int id, int id2);
        Task Create(Envio_Servicio_CiudadDto request);
        Task Update(Envio_Servicio_CiudadDto request);
    }
}
