using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class UniartDbContext:DbContext
    {
        public UniartDbContext(DbContextOptions<UniartDbContext>options):base(options)
        {

        }

        public UniartDbContext() 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            optionBuilder.UseSqlServer(@"Server = DESKTOP-RAJ8SM1; Database = UniartDb; Integrated Security = true;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta_Usuario> Cuenta_Usuarios { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<trabajo> trabajos { get; set; }
        public DbSet<tipo_pago> tipo_pagos { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<estado_propuesta> estado_propuestas { get; set; }
        public DbSet<duracion_esperada> duracion_esperadas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<complejidad> complejidades { get; set; }
    }
}
