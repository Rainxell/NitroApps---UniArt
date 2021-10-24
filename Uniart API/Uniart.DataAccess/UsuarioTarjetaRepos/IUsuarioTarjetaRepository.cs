using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IUsuarioTarjetaRepository
    {
        Task<Usuario_Tarjeta> Get(int userid, int tarjetaid);
        Task Create(Usuario_Tarjeta entity);
    }
}
