using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IUsuarioRepository
    {
        Task<ICollection<Usuario>> GetCollection(string filter);

        Task<Usuario> GetUsuario(int id);
        Task Create(Usuario entity);

        Task Update(Usuario entity);

        Task Delete(int id);

    }
}
