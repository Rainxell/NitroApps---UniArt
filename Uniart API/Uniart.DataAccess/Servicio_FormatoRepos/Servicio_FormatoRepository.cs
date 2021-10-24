using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Servicio_FormatoRepository: IServicio_FormatoRepository
    {
        private readonly UniartDbContext _context;

        public Servicio_FormatoRepository(UniartDbContext context)
        {
            _context = context;
        }

        

        public async Task<Servicio_Formato> Get(int id, int id2)
        {
            return await _context.Servicios_Formatos.FindAsync(id, id2);
        }

        public async Task Create(Servicio_Formato entity)
        {
            await _context.Set<Servicio_Formato>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Servicio_Formato entity)
        {
            _context.Set<Servicio_Formato>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}
