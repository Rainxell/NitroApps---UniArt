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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio_Servicio_Ciudad>().HasKey(sc => new { sc.Servicio_id, sc.Ciudad_id });
            modelBuilder.Entity<Red_Social_Artista>().HasKey(sc => new { sc.Red_social_id, sc.Artista_id });
            modelBuilder.Entity<Servicio_Formato>().HasKey(sc => new { sc.Formato_id, sc.Servicio_id });
            modelBuilder.Entity<Servicio_Tema>().HasKey(sc => new { sc.Tema_id, sc.Servicio_id });
            modelBuilder.Entity<Usuario_Tarjeta>().HasKey(sc => new { sc.Tarjeta_id, sc.Usuario_id });
            modelBuilder.Entity<Variacion_Detalle>().HasKey(sc => new { sc.Servicio_Variacion_id, sc.Caracteristica_Opciones_id });
            modelBuilder.Entity<Valoracion>().HasKey(sc => new { sc.Usuario_id, sc.Review_id });

        }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Caracteristica_Opciones> Caracteristicas_Opciones { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Envio_Servicio_Ciudad> Envios_Servicios_Ciudades { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<Formato> Formatos { get; set; }
        public DbSet<Licencia> Licencias { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Red_Social> Redes_Sociales { get; set; }
        public DbSet<Red_Social_Artista> Redes_Sociales_Artistas { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Servicio_Caracteristica> Servicios_Caracteristicas { get; set; }
        public DbSet<Servicio_Formato> Servicios_Formatos { get; set; }
        public DbSet<Servicio_Tema> Servicios_Temas { get; set; }
        public DbSet<Servicio_Variacion> Servicios_Variaciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Tecnica> Tecnicas { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Usuario_Tarjeta> Usuarios_Tarjetas { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }
        public DbSet<Variacion_Detalle> Variacion_Detalles { get; set; }

    }
}
