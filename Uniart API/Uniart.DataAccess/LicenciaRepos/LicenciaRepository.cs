using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class LicenciaRepository
    {
        private readonly UniartDbContext _context;

        public LicenciaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Licencia>> GetCollection(string filter)
        {
            var collection = await _context.Licencias
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Licencia> Get(int id)
        {
            return await _context.Licencias.FindAsync(id);
        }

        public async Task Create(Licencia entity)
        {
            await _context.Set<Licencia>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Licencia entity)
        {
            _context.Set<Licencia>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Licencias.FindAsync(id);
            _context.Licencias.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
