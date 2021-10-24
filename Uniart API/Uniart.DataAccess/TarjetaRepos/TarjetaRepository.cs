using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class TarjetaRepository:ITarjetaRepository
    {
        private readonly UniartDbContext _context;

        public TarjetaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Tarjeta entity)
        {
            await _context.Set<Tarjeta>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tarjetaToDelete = await _context.Tarjetas.FindAsync(id);
            _context.Tarjetas.Remove(tarjetaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Tarjeta> Get(int id)
        {
            return await _context.Tarjetas.FindAsync(id);
        }

        public async Task<ICollection<Tarjeta>> GetCollection(string filter)
        {
            var collection = await _context.Tarjetas
               .Where(c => c.Nombre_completo.Contains(filter))
               .ToListAsync();

            return collection;
        }

        public async Task Update(Tarjeta entity)
        {
            _context.Set<Tarjeta>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }
    }
}
