using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Servicio_TemaRepository:IServicio_TemaRepository
    {
        private readonly UniartDbContext _context;

        public Servicio_TemaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Servicio_Tema entity)
        {
            await _context.Set<Servicio_Tema>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Servicio_Tema> Get(int id1, int id2)
        {
            return await _context.Servicios_Temas.FindAsync(id1, id2);
        }
    }
}
