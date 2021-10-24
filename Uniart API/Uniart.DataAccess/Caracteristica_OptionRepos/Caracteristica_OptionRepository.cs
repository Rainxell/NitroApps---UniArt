using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Caracteristica_OptionRepository: ICaracteristica_OptionRepository
    {
        private readonly UniartDbContext _context;

        public Caracteristica_OptionRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Caracteristica_Opciones>> GetCollection(string filter)
        {
            var collection = await _context.Caracteristicas_Opciones
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Caracteristica_Opciones> GetCaracteristica_Option(int id)
        {
            return await _context.Caracteristicas_Opciones.FindAsync(id);
        }

        public async Task Create(Caracteristica_Opciones entity)
        {
            await _context.Set<Caracteristica_Opciones>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Caracteristica_Opciones entity)
        {
            _context.Set<Caracteristica_Opciones>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Caracteristica_OptionToDelete = await _context.Caracteristicas_Opciones.FindAsync(id);
            _context.Caracteristicas_Opciones.Remove(Caracteristica_OptionToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
