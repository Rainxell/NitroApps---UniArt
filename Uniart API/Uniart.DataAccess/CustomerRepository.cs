using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly UniartDbContext _context;
        public CustomerRepository(UniartDbContext context)
        {
            _context = context;
        }
        public void Create(Cuenta_Usuario entity)
        {
            _context.Set<Cuenta_Usuario>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           _context.Entry(new Cuenta_Usuario
           { 
                Id = id
            }).State = EntityState.Deleted;
            _context.SaveChanges();
        }


        public ICollection<Cuenta_Usuario> GetCollection(string filter)
        {
            return _context.Cuenta_Usuarios
                .Where(c => c.nombre.Contains(filter))
                .ToList();
        }

        public Cuenta_Usuario GetItem(int id)
        {
            return _context.Cuenta_Usuarios.Find(id);
        }

        public void Update(Cuenta_Usuario entity)
        {
            _context.Set<Cuenta_Usuario>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
