using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class ServicioRepository: IServicioRepository
    {
        private readonly UniartDbContext _context;

        public ServicioRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Servicio>> GetCollection(string filter)
        {
            var collection = await _context.Servicios
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Servicio> Get(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task Create(Servicio entity)
        {
            await _context.Set<Servicio>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Servicio entity)
        {
            _context.Set<Servicio>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Servicios.FindAsync(id);
            _context.Servicios.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
