using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IServicio_TemaRepository
    {
        Task<Servicio_Tema> Get(int id1, int id2);
        Task Create(Servicio_Tema entity);

    }
}
