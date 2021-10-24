using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IUsuarioTarjetaService
    {
        Task<ResponseDto<UsuarioTarjetaDto>> Get(int userid, int tarjetaid);
        Task Create(UsuarioTarjetaDto request);
        
    }
}
