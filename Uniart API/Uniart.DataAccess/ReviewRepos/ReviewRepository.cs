using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly UniartDbContext _context;

        public ReviewRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Review>> GetCollection(string filter)
        {
            var collection = await _context.Reviews
                .Where(c => c.Id.ToString().Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Review> Get(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task Create(Review entity)
        {
            await _context.Set<Review>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Review entity)
        {
            _context.Set<Review>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
