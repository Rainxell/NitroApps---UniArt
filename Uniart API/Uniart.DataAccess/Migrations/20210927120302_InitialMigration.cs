using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uniart.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "complejidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    complejidad_text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complejidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "duracion_esperadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    duracion_text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duracion_esperadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estado_propuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_estado = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_propuestas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_pagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuenta_Usuario_id = table.Column<int>(type: "int", nullable: false),
                    Cuenta_UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    localizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artistas_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artistas_Cuenta_Usuarios_Cuenta_UsuarioId",
                        column: x => x.Cuenta_UsuarioId,
                        principalTable: "Cuenta_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuenta_Usuario_id = table.Column<int>(type: "int", nullable: false),
                    Cuenta_UsuarioId = table.Column<int>(type: "int", nullable: true),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    localizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Cuenta_Usuarios_Cuenta_UsuarioId",
                        column: x => x.Cuenta_UsuarioId,
                        principalTable: "Cuenta_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_pago_id = table.Column<int>(type: "int", nullable: false),
                    tipo_pagoId = table.Column<int>(type: "int", nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monto_pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_tipo_pagos_tipo_pagoId",
                        column: x => x.tipo_pagoId,
                        principalTable: "tipo_pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artista_id = table.Column<int>(type: "int", nullable: false),
                    ArtistaId = table.Column<int>(type: "int", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repositories_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trabajos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_id = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    duracion_esperada_id = table.Column<int>(type: "int", nullable: false),
                    duracion_esperadaId = table.Column<int>(type: "int", nullable: true),
                    complejidad_id = table.Column<int>(type: "int", nullable: false),
                    complejidadId = table.Column<int>(type: "int", nullable: true),
                    tipo_pago_id = table.Column<int>(type: "int", nullable: false),
                    tipo_pagoId = table.Column<int>(type: "int", nullable: true),
                    monto_pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    hora_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajos_complejidades_complejidadId",
                        column: x => x.complejidadId,
                        principalTable: "complejidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajos_duracion_esperadas_duracion_esperadaId",
                        column: x => x.duracion_esperadaId,
                        principalTable: "duracion_esperadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajos_tipo_pagos_tipo_pagoId",
                        column: x => x.tipo_pagoId,
                        principalTable: "tipo_pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artista_id = table.Column<int>(type: "int", nullable: false),
                    ArtistaId = table.Column<int>(type: "int", nullable: true),
                    Cliente_id = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    tipo_pago_id = table.Column<int>(type: "int", nullable: false),
                    tipo_pagoId = table.Column<int>(type: "int", nullable: true),
                    estado_propuesta_id = table.Column<int>(type: "int", nullable: false),
                    estado_propuestaId = table.Column<int>(type: "int", nullable: true),
                    trabajo_id = table.Column<int>(type: "int", nullable: false),
                    trabajoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propuestas_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propuestas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propuestas_estado_propuestas_estado_propuestaId",
                        column: x => x.estado_propuestaId,
                        principalTable: "estado_propuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propuestas_tipo_pagos_tipo_pagoId",
                        column: x => x.tipo_pagoId,
                        principalTable: "tipo_pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propuestas_trabajos_trabajoId",
                        column: x => x.trabajoId,
                        principalTable: "trabajos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artista_id = table.Column<int>(type: "int", nullable: false),
                    ArtistaId = table.Column<int>(type: "int", nullable: true),
                    Cliente_id = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Propuesta_id = table.Column<int>(type: "int", nullable: false),
                    PropuestaId = table.Column<int>(type: "int", nullable: true),
                    estado_propuesta_id = table.Column<int>(type: "int", nullable: false),
                    estado_propuestaId = table.Column<int>(type: "int", nullable: true),
                    hora_mensaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    texto_mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensajes_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensajes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensajes_estado_propuestas_estado_propuestaId",
                        column: x => x.estado_propuestaId,
                        principalTable: "estado_propuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensajes_Propuestas_PropuestaId",
                        column: x => x.PropuestaId,
                        principalTable: "Propuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_CategoryId",
                table: "Artistas",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_Cuenta_UsuarioId",
                table: "Artistas",
                column: "Cuenta_UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cuenta_UsuarioId",
                table: "Clientes",
                column: "Cuenta_UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_tipo_pagoId",
                table: "Contratos",
                column: "tipo_pagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_ArtistaId",
                table: "Mensajes",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_ClienteId",
                table: "Mensajes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_estado_propuestaId",
                table: "Mensajes",
                column: "estado_propuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_PropuestaId",
                table: "Mensajes",
                column: "PropuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_ArtistaId",
                table: "Propuestas",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_ClienteId",
                table: "Propuestas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_estado_propuestaId",
                table: "Propuestas",
                column: "estado_propuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_tipo_pagoId",
                table: "Propuestas",
                column: "tipo_pagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propuestas_trabajoId",
                table: "Propuestas",
                column: "trabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Repositories_ArtistaId",
                table: "Repositories",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_trabajos_ClienteId",
                table: "trabajos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_trabajos_complejidadId",
                table: "trabajos",
                column: "complejidadId");

            migrationBuilder.CreateIndex(
                name: "IX_trabajos_duracion_esperadaId",
                table: "trabajos",
                column: "duracion_esperadaId");

            migrationBuilder.CreateIndex(
                name: "IX_trabajos_tipo_pagoId",
                table: "trabajos",
                column: "tipo_pagoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Repositories");

            migrationBuilder.DropTable(
                name: "Propuestas");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "estado_propuestas");

            migrationBuilder.DropTable(
                name: "trabajos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "complejidades");

            migrationBuilder.DropTable(
                name: "duracion_esperadas");

            migrationBuilder.DropTable(
                name: "tipo_pagos");

            migrationBuilder.DropTable(
                name: "Cuenta_Usuarios");
        }
    }
}
