using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class MensajeRepository: IMensajeRepository
    {
        private readonly UniartDbContext _context;

        public MensajeRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Mensaje>> GetCollection(string filter)
        {
            var collection = await _context.Mensajes
                .Where(c => c.Texto_mensaje.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Mensaje> Get(int id)
        {
            return await _context.Mensajes.FindAsync(id);
        }

        public async Task Create(Mensaje entity)
        {
            await _context.Set<Mensaje>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Mensaje entity)
        {
            _context.Set<Mensaje>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Mensajes.FindAsync(id);
            _context.Mensajes.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
