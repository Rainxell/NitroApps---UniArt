using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class PropuestaRepository: IPropuestaRepository
    {
        private readonly UniartDbContext _context;

        public PropuestaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Propuesta>> GetCollection(string filter)
        {
            var collection = await _context.Propuestas
                .Where(c => c.Descripcion.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Propuesta> Get(int id)
        {
            return await _context.Propuestas.FindAsync(id);
        }

        public async Task Create(Propuesta entity)
        {
            await _context.Set<Propuesta>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Propuesta entity)
        {
            _context.Set<Propuesta>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Propuestas.FindAsync(id);
            _context.Propuestas.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
