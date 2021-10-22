using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class PaisRepository : IPaisRepository
    {
        private readonly UniartDbContext _context;
        public PaisRepository(UniartDbContext context)
        {
            _context = context;
        }
        public async Task Create(Pais entity)
        {
            await _context.Set<Pais>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Pais
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Pais>> GetCollection(string filter)
        {
            var collection = await _context.Paises
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Pais> GetPais(int id)
        {
            return await _context.Paises.FindAsync(id);
        }

        public async Task Update(Pais entity)
        {
            _context.Set<Pais>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}
