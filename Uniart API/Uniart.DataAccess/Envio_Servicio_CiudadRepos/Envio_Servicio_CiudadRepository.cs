using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.Envio_Servicio_CiudadRepos
{
    public class Envio_Servicio_CiudadRepository: IEnvio_Servicio_CiudadRepository
    {
        private readonly UniartDbContext _context;

        public Envio_Servicio_CiudadRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<Envio_Servicio_Ciudad> Get(int id, int id2)
        {
            return await _context.Envios_Servicios_Ciudades.FindAsync(id, id2);
            
        }

        public async Task Create(Envio_Servicio_Ciudad entity)
        {
            await _context.Set<Envio_Servicio_Ciudad>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Envio_Servicio_Ciudad entity)
        {
            _context.Set<Envio_Servicio_Ciudad>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}
