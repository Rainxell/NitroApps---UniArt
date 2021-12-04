using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IUsuarioService
    {
        Task<ICollection<UsuarioDto>> GetCollection(string filter);
        Task<ResponseDto<UsuarioDto>> GetUsuario(int id);

        Task Create(UsuarioDto request);

        //Task Update(int id, UsuarioDto request);

        Task Delete(int id);
    }
}
