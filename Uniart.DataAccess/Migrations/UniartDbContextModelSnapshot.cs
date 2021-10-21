﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uniart.DataAccess;

namespace Uniart.DataAccess.Migrations
{
    [DbContext(typeof(UniartDbContext))]
    partial class UniartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Uniart.Entities.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<int?>("Cuenta_UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Cuenta_Usuario_id")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("fecha_registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("localizacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Cuenta_UsuarioId");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Uniart.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Uniart.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cuenta_UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Cuenta_Usuario_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("localizacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Cuenta_UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Uniart.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fecha_fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_inicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("monto_pago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("tipo_pagoId")
                        .HasColumnType("int");

                    b.Property<int>("tipo_pago_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tipo_pagoId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Uniart.Entities.Cuenta_Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Cuenta_Usuarios");
                });

            modelBuilder.Entity("Uniart.Entities.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<int>("Artista_id")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Cliente_id")
                        .HasColumnType("int");

                    b.Property<int?>("PropuestaId")
                        .HasColumnType("int");

                    b.Property<int>("Propuesta_id")
                        .HasColumnType("int");

                    b.Property<int?>("estado_propuestaId")
                        .HasColumnType("int");

                    b.Property<int>("estado_propuesta_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("hora_mensaje")
                        .HasColumnType("datetime2");

                    b.Property<string>("texto_mensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PropuestaId");

                    b.HasIndex("estado_propuestaId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("Uniart.Entities.Propuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<int>("Artista_id")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Cliente_id")
                        .HasColumnType("int");

                    b.Property<int?>("estado_propuestaId")
                        .HasColumnType("int");

                    b.Property<int>("estado_propuesta_id")
                        .HasColumnType("int");

                    b.Property<int?>("tipo_pagoId")
                        .HasColumnType("int");

                    b.Property<int>("tipo_pago_id")
                        .HasColumnType("int");

                    b.Property<int?>("trabajoId")
                        .HasColumnType("int");

                    b.Property<int>("trabajo_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("estado_propuestaId");

                    b.HasIndex("tipo_pagoId");

                    b.HasIndex("trabajoId");

                    b.ToTable("Propuestas");
                });

            modelBuilder.Entity("Uniart.Entities.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<int>("Artista_id")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("Uniart.Entities.complejidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("complejidad_text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("complejidades");
                });

            modelBuilder.Entity("Uniart.Entities.duracion_esperada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("duracion_text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("duracion_esperadas");
                });

            modelBuilder.Entity("Uniart.Entities.estado_propuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre_estado")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("estado_propuestas");
                });

            modelBuilder.Entity("Uniart.Entities.tipo_pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tipo_nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("tipo_pagos");
                });

            modelBuilder.Entity("Uniart.Entities.trabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Cliente_id")
                        .HasColumnType("int");

                    b.Property<int?>("complejidadId")
                        .HasColumnType("int");

                    b.Property<int>("complejidad_id")
                        .HasColumnType("int");

                    b.Property<int?>("duracion_esperadaId")
                        .HasColumnType("int");

                    b.Property<int>("duracion_esperada_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("hora_fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("hora_inicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("monto_pago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("tipo_pagoId")
                        .HasColumnType("int");

                    b.Property<int>("tipo_pago_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("complejidadId");

                    b.HasIndex("duracion_esperadaId");

                    b.HasIndex("tipo_pagoId");

                    b.ToTable("trabajos");
                });

            modelBuilder.Entity("Uniart.Entities.Artista", b =>
                {
                    b.HasOne("Uniart.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Uniart.Entities.Cuenta_Usuario", "Cuenta_Usuario")
                        .WithMany()
                        .HasForeignKey("Cuenta_UsuarioId");

                    b.Navigation("Category");

                    b.Navigation("Cuenta_Usuario");
                });

            modelBuilder.Entity("Uniart.Entities.Cliente", b =>
                {
                    b.HasOne("Uniart.Entities.Cuenta_Usuario", "Cuenta_Usuario")
                        .WithMany()
                        .HasForeignKey("Cuenta_UsuarioId");

                    b.Navigation("Cuenta_Usuario");
                });

            modelBuilder.Entity("Uniart.Entities.Contrato", b =>
                {
                    b.HasOne("Uniart.Entities.tipo_pago", "tipo_pago")
                        .WithMany()
                        .HasForeignKey("tipo_pagoId");

                    b.Navigation("tipo_pago");
                });

            modelBuilder.Entity("Uniart.Entities.Mensaje", b =>
                {
                    b.HasOne("Uniart.Entities.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaId");

                    b.HasOne("Uniart.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Uniart.Entities.Propuesta", "Propuesta")
                        .WithMany()
                        .HasForeignKey("PropuestaId");

                    b.HasOne("Uniart.Entities.estado_propuesta", "estado_propuesta")
                        .WithMany()
                        .HasForeignKey("estado_propuestaId");

                    b.Navigation("Artista");

                    b.Navigation("Cliente");

                    b.Navigation("estado_propuesta");

                    b.Navigation("Propuesta");
                });

            modelBuilder.Entity("Uniart.Entities.Propuesta", b =>
                {
                    b.HasOne("Uniart.Entities.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaId");

                    b.HasOne("Uniart.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Uniart.Entities.estado_propuesta", "estado_propuesta")
                        .WithMany()
                        .HasForeignKey("estado_propuestaId");

                    b.HasOne("Uniart.Entities.tipo_pago", "tipo_pago")
                        .WithMany()
                        .HasForeignKey("tipo_pagoId");

                    b.HasOne("Uniart.Entities.trabajo", "trabajo")
                        .WithMany()
                        .HasForeignKey("trabajoId");

                    b.Navigation("Artista");

                    b.Navigation("Cliente");

                    b.Navigation("estado_propuesta");

                    b.Navigation("tipo_pago");

                    b.Navigation("trabajo");
                });

            modelBuilder.Entity("Uniart.Entities.Repository", b =>
                {
                    b.HasOne("Uniart.Entities.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaId");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("Uniart.Entities.trabajo", b =>
                {
                    b.HasOne("Uniart.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Uniart.Entities.complejidad", "complejidad")
                        .WithMany()
                        .HasForeignKey("complejidadId");

                    b.HasOne("Uniart.Entities.duracion_esperada", "duracion_esperada")
                        .WithMany()
                        .HasForeignKey("duracion_esperadaId");

                    b.HasOne("Uniart.Entities.tipo_pago", "tipo_pago")
                        .WithMany()
                        .HasForeignKey("tipo_pagoId");

                    b.Navigation("Cliente");

                    b.Navigation("complejidad");

                    b.Navigation("duracion_esperada");

                    b.Navigation("tipo_pago");
                });
#pragma warning restore 612, 618
        }
    }
}
