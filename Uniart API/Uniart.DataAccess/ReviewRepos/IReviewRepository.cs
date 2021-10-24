using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetCollection(string filter);

        Task<Review> Get(int id);
        Task Create(Review entity);

        Task Update(Review entity);

        Task Delete(int id);
    }
}
