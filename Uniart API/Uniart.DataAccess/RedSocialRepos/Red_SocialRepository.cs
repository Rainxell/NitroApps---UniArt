using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Red_SocialRepository : IRed_SocialRepository
    {
        private readonly UniartDbContext _context;

        public Red_SocialRepository(UniartDbContext context)
        {
            _context = context;
        }
        public async Task Create(Red_Social entity)
        {
            await _context.Set<Red_Social>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var red_socialToDelete = await _context.Redes_Sociales.FindAsync(id);
            _context.Redes_Sociales.Remove(red_socialToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Red_Social> GetRedes(int id)
        {
            return await _context.Redes_Sociales.FindAsync(id);
        }

        public async Task<ICollection<Red_Social>> GetCollection(string filter)
        {
            var collection = await _context.Redes_Sociales
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task Update(Red_Social entity)
        {
            _context.Set<Red_Social>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
