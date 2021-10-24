using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.EnvioRepos
{
    public interface IEnvioRepository
    {

        Task<ICollection<Envio>> GetCollection(string filter);

        Task<Envio> GetEnvio(int id);
        Task Create(Envio entity);

        Task Update(Envio entity);

        Task Delete(int id);
    }
}
