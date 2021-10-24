using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class TecnicaRepository:ITecnicaRepository
    {
        private readonly UniartDbContext _context;

        public TecnicaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Tecnica entity)
        {
            await _context.Set<Tecnica>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tecnicaToDelete = await _context.Tecnicas.FindAsync(id);
            _context.Tecnicas.Remove(tecnicaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Tecnica> Get(int id)
        {
            return await _context.Tecnicas.FindAsync(id);
        }

        public async Task<ICollection<Tecnica>> GetCollection(string filter)
        {
            var collection = await _context.Tecnicas
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task Update(Tecnica entity)
        {
            _context.Set<Tecnica>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
