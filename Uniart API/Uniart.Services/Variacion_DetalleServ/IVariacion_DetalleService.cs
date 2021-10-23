using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services.Variacion_DetalleServ
{
    public interface IVariacion_DetalleService
    {
        Task<ResponseDto<Variacion_DetalleDto>> Get(int SV_id, int CO_id);
        Task Create(Variacion_DetalleDto request);
        Task Update(Variacion_DetalleDto request);
    }
}
