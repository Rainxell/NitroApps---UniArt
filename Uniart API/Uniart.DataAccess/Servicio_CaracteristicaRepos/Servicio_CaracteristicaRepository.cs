using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Servicio_CaracteristicaRepository: IServicio_CaracteristicaRepository
    {
        private readonly UniartDbContext _context;

        public Servicio_CaracteristicaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Servicio_Caracteristica>> GetCollection(string filter)
        {
            var collection = await _context.Servicios_Caracteristicas
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Servicio_Caracteristica> Get(int id)
        {
            return await _context.Servicios_Caracteristicas.FindAsync(id);
        }

        public async Task Create(Servicio_Caracteristica entity)
        {
            await _context.Set<Servicio_Caracteristica>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Servicio_Caracteristica entity)
        {
            _context.Set<Servicio_Caracteristica>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Servicios_Caracteristicas.FindAsync(id);
            _context.Servicios_Caracteristicas.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
