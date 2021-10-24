using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ITemaRepository
    {
        Task<ICollection<Tema>> GetCollection(string filter);

        Task<Tema> Get(int id);
        Task Create(Tema entity);

        Task Update(Tema entity);

        Task Delete(int id);
    }
}
