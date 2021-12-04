using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uniart.DataAccess.Config;
using Uniart.Entities;
using Uniart.Entities.identity;

namespace Uniart.DataAccess
{
    public class UniartDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public UniartDbContext(DbContextOptions<UniartDbContext>options):base(options)
        {

        }

        public UniartDbContext() 
        {
        
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    if (!optionBuilder.IsConfigured)
        //    {
        //        optionBuilder.UseMySQL("Server=us-cdbr-east-04.cleardb.com; Port=3306; Database=heroku_b281a3c727808fc; user=b348795db55ea8; password=5e8d388e");
        //    }
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //"Server = den1.mssql8.gear.host; Database = uniartdb;Trusted_Connection=True;Integrated Security=false;User Id=uniartdb;Password=Yd7u?!eYnN7b"
                optionsBuilder.UseSqlServer(@"Server = den1.mssql7.gear.host; Database = uniartbd;Trusted_Connection=True;Integrated Security=false;User Id=uniartbd;Password=Vz26Pl9PD8--");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
            new ApplicationUserConfig(modelBuilder.Entity<ApplicationUser>());
            new ApplicationRoleConfig(modelBuilder.Entity<ApplicationRole>());
            modelBuilder.Entity<Ciudad>().HasOne(p => p.Pais).WithMany(b => b.Ciudades).HasForeignKey(p=>p.Pais_id).IsRequired();
            modelBuilder.Entity<Pais>().Navigation(b => b.Ciudades).UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<Servicio>().HasOne(p => p.Artista).WithMany(b => b.Servicios).HasForeignKey(p => p.Artista_id).IsRequired();
            modelBuilder.Entity<Envio_Servicio_Ciudad>().HasKey(sc => new { sc.Servicio_id, sc.Ciudad_id });
            modelBuilder.Entity<Red_Social_Artista>().HasKey(sc => new { sc.Red_social_id, sc.Artista_id });
            modelBuilder.Entity<Servicio_Formato>().HasKey(sc => new { sc.Formato_id, sc.Servicio_id });
            modelBuilder.Entity<Servicio_Tema>().HasKey(sc => new { sc.Tema_id, sc.Servicio_id });
            modelBuilder.Entity<Usuario_Tarjeta>().HasKey(sc => new { sc.Tarjeta_id, sc.Usuario_id });
            modelBuilder.Entity<Variacion_Detalle>().HasKey(sc => new { sc.Servicio_Variacion_id, sc.Caracteristica_Opciones_id });
            modelBuilder.Entity<Valoracion>().HasKey(sc => new { sc.Usuario_id, sc.Review_id });
            modelBuilder.Entity<Comision>().HasOne(p => p.Servicio_).WithMany(b => b.Comisiones).HasForeignKey(p => p.Servicio_id).IsRequired();
           // modelBuilder.Entity<Comision>().HasOne(p => p.Review_id_Artista).WithMany(b => b.Comisiones).HasForeignKey(p => p.Review_Artista_id).IsRequired();
            modelBuilder.Entity<Comision>().HasOne(p => p.Review_id_Cliente).WithMany(b => b.Comisiones).HasForeignKey(p => p.Review_Usuario_id).IsRequired();
            modelBuilder.Entity<Comision>().HasOne(p => p.Usuario_).WithMany(b => b.ComisionesU).HasForeignKey(p => p.Usuario_id);
            modelBuilder.Entity<Comision>().HasOne(p => p.Servicio_Variacio_).WithMany(b => b.ComisionSV).HasForeignKey(p => p.Servicio_Variacion_id).IsRequired();
            modelBuilder.Entity<ApplicationUser>().HasOne(p => p.Ciudad_).WithMany(b => b.Ciudades).HasForeignKey(p => p.Ciudad_id).IsRequired();
            modelBuilder.Entity<Artista>().HasOne(p=>p.Artista_).WithMany(b => b.artistas).HasForeignKey(p => p.Id).IsRequired();
            modelBuilder.Entity<Usuario>().HasOne(p => p.Usuario_).WithMany(b => b.usuarios).HasForeignKey(p => p.Id).IsRequired();
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
        //public DbSet<Propuesta> Propuestas { get; set; }
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
