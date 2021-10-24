using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ITarjetaRepository
    {
        Task<ICollection<Tarjeta>> GetCollection(string filter);

        Task<Tarjeta> Get(int id);
        Task Create(Tarjeta entity);

        Task Update(Tarjeta entity);

        Task Delete(int id);
    }
}
