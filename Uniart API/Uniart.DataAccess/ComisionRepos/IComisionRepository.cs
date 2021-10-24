using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.ComisionRepos
{
    public interface IComisionRepository
    {

        Task<Comision> GetComision(int id);

        Task Create(Comision entity);

        Task Update(Comision entity);

        Task Delete(int id);
    }
}
