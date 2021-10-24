using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Servicio_VariacionRepository:IServicio_VariacionRepository
    {
        private readonly UniartDbContext _context;

        public Servicio_VariacionRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Servicio_Variacion entity)
        {
            await _context.Set<Servicio_Variacion>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var serviciovarToDelete = await _context.Servicios_Variaciones.FindAsync(id);
            _context.Servicios_Variaciones.Remove(serviciovarToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Servicio_Variacion> Get(int id)
        {
            return await _context.Servicios_Variaciones.FindAsync(id);
        }

        public async Task<ICollection<Servicio_Variacion>> GetCollection(string filter)
        {
            var collection = await _context.Servicios_Variaciones
                .Where(c => c.Id.ToString().Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task Update(Servicio_Variacion entity)
        {
            _context.Set<Servicio_Variacion>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
