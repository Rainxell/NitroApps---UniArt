using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IRed_SocialRepository
    {
        Task<ICollection<Red_Social>> GetCollection(string filter);

        Task<Red_Social> GetRedes(int id);
        Task Create(Red_Social entity);

        Task Update(Red_Social entity);

        Task Delete(int id);
    }
}
