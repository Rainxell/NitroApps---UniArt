using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class TemaRepository:ITemaRepository
    {
        private readonly UniartDbContext _context;

        public TemaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Tema entity)
        {
            await _context.Set<Tema>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Temas.FindAsync(id);
            _context.Temas.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Tema> Get(int id)
        {
            return await _context.Temas.FindAsync(id);
        }

        public async Task<ICollection<Tema>> GetCollection(string filter)
        {
            var collection = await _context.Temas
                 .Where(c => c.Nombre.Contains(filter))
                 .ToListAsync();

            return collection;
        }

        public async Task Update(Tema entity)
        {
            _context.Set<Tema>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
