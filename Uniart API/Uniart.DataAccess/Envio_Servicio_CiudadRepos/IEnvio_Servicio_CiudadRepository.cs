using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.Envio_Servicio_CiudadRepos
{
    public interface IEnvio_Servicio_CiudadRepository
    {
      
        Task<Envio_Servicio_Ciudad> Get(int id1, int id2);
        Task Create(Envio_Servicio_Ciudad entity);

        Task Update(Envio_Servicio_Ciudad entity);

    }
}
