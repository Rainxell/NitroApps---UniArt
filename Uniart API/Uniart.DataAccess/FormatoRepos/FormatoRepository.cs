using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class FormatoRepository: IFormatoRepository
    {
        private readonly UniartDbContext _context;

        public FormatoRepository(UniartDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Formato>> GetCollection(string filter)
        {
            var collection = await _context.Formatos
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Formato> Get(int id)
        {
            return await _context.Formatos.FindAsync(id);
        }

        public async Task Create(Formato entity)
        {
            await _context.Set<Formato>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Formato entity)
        {
            _context.Set<Formato>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Formatos.FindAsync(id);
            _context.Formatos.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
