using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uniart.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estilos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redes_Sociales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redes_Sociales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating_cliente = table.Column<short>(type: "smallint", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_Positivo = table.Column<int>(type: "int", nullable: false),
                    Valor_Negativo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Caracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios_Caracteristicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_tarjeta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Nombre_completo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Fecha_vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvc = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Paises_Pais_id",
                        column: x => x.Pais_id,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caracteristicas_Opciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Servicio_Caracteristica_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristicas_Opciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caracteristicas_Opciones_Servicios_Caracteristicas_Servicio_Caracteristica_Id",
                        column: x => x.Servicio_Caracteristica_Id,
                        principalTable: "Servicios_Caracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Ciudad_id = table.Column<int>(type: "int", nullable: false),
                    Url_foto_perfil = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    esArtista = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Url_foto_portada = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    Q_valoraciones = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Ciudades_Ciudad_id",
                        column: x => x.Ciudad_id,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artistas_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Redes_Sociales_Artistas",
                columns: table => new
                {
                    Red_social_id = table.Column<int>(type: "int", nullable: false),
                    Artista_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redes_Sociales_Artistas", x => new { x.Red_social_id, x.Artista_id });
                    table.ForeignKey(
                        name: "FK_Redes_Sociales_Artistas_Artistas_Artista_id",
                        column: x => x.Artista_id,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Redes_Sociales_Artistas_Redes_Sociales_Red_social_id",
                        column: x => x.Red_social_id,
                        principalTable: "Redes_Sociales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Artista_id = table.Column<int>(type: "int", nullable: false),
                    Duracion_esperada = table.Column<TimeSpan>(type: "time", nullable: false),
                    Precio_base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    Q_valoraciones = table.Column<int>(type: "int", nullable: false),
                    Es_virtual = table.Column<bool>(type: "bit", nullable: false),
                    Porc_adelanto = table.Column<int>(type: "int", nullable: false),
                    acepta_rembolso = table.Column<bool>(type: "bit", nullable: false),
                    Estilo_Id = table.Column<int>(type: "int", nullable: true),
                    Tecnica_Id = table.Column<int>(type: "int", nullable: true),
                    Acerca_servicio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Licencia_Id = table.Column<int>(type: "int", nullable: true),
                    Q_reviciones = table.Column<int>(type: "int", nullable: false),
                    url_imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Artistas_Artista_id",
                        column: x => x.Artista_id,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Estilos_Estilo_Id",
                        column: x => x.Estilo_Id,
                        principalTable: "Estilos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Licencias_Licencia_Id",
                        column: x => x.Licencia_Id,
                        principalTable: "Licencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Tecnicas_Tecnica_Id",
                        column: x => x.Tecnica_Id,
                        principalTable: "Tecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artista_Id = table.Column<int>(type: "int", nullable: true),
                    Usuario_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Redes_Sociales_Artista_Id",
                        column: x => x.Artista_Id,
                        principalTable: "Redes_Sociales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Usuarios_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios_Tarjetas",
                columns: table => new
                {
                    Tarjeta_id = table.Column<int>(type: "int", nullable: false),
                    Usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios_Tarjetas", x => new { x.Tarjeta_id, x.Usuario_id });
                    table.ForeignKey(
                        name: "FK_Usuarios_Tarjetas_Tarjetas_Tarjeta_id",
                        column: x => x.Tarjeta_id,
                        principalTable: "Tarjetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Tarjetas_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valoraciones",
                columns: table => new
                {
                    Usuario_id = table.Column<int>(type: "int", nullable: false),
                    Review_id = table.Column<int>(type: "int", nullable: false),
                    Es_like = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoraciones", x => new { x.Usuario_id, x.Review_id });
                    table.ForeignKey(
                        name: "FK_Valoraciones_Reviews_Review_id",
                        column: x => x.Review_id,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Valoraciones_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Envios_Servicios_Ciudades",
                columns: table => new
                {
                    Servicio_id = table.Column<int>(type: "int", nullable: false),
                    Ciudad_id = table.Column<int>(type: "int", nullable: false),
                    Costo_envio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios_Servicios_Ciudades", x => new { x.Servicio_id, x.Ciudad_id });
                    table.ForeignKey(
                        name: "FK_Envios_Servicios_Ciudades_Ciudades_Ciudad_id",
                        column: x => x.Ciudad_id,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Envios_Servicios_Ciudades_Servicios_Servicio_id",
                        column: x => x.Servicio_id,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Formatos",
                columns: table => new
                {
                    Formato_id = table.Column<int>(type: "int", nullable: false),
                    Servicio_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios_Formatos", x => new { x.Formato_id, x.Servicio_id });
                    table.ForeignKey(
                        name: "FK_Servicios_Formatos_Formatos_Formato_id",
                        column: x => x.Formato_id,
                        principalTable: "Formatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Formatos_Servicios_Servicio_id",
                        column: x => x.Servicio_id,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Temas",
                columns: table => new
                {
                    Tema_id = table.Column<int>(type: "int", nullable: false),
                    Servicio_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios_Temas", x => new { x.Tema_id, x.Servicio_id });
                    table.ForeignKey(
                        name: "FK_Servicios_Temas_Servicios_Servicio_id",
                        column: x => x.Servicio_id,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Temas_Temas_Tema_id",
                        column: x => x.Tema_id,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Variaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicio_Id = table.Column<int>(type: "int", nullable: true),
                    Incluir_editable = table.Column<bool>(type: "bit", nullable: false),
                    Licencia_Id = table.Column<int>(type: "int", nullable: true),
                    Q_reviciones = table.Column<int>(type: "int", nullable: false),
                    Duracion_esperada = table.Column<TimeSpan>(type: "time", nullable: false),
                    precio_base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Url_imagen_referencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios_Variaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Variaciones_Licencias_Licencia_Id",
                        column: x => x.Licencia_Id,
                        principalTable: "Licencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Variaciones_Servicios_Servicio_Id",
                        column: x => x.Servicio_Id,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chat_Id = table.Column<int>(type: "int", nullable: true),
                    Hora_mensaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto_mensaje = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensajes_Chats_Chat_Id",
                        column: x => x.Chat_Id,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comisiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Porc_avance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto_pago_inicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto_pago_final = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Servicio_id = table.Column<int>(type: "int", nullable: false),
                    Review_Usuario_id = table.Column<int>(type: "int", nullable: false),
                    Usuario_id = table.Column<int>(type: "int", nullable: false),
                    Servicio_Variacion_id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comisiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comisiones_Reviews_Review_Usuario_id",
                        column: x => x.Review_Usuario_id,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comisiones_Servicios_Servicio_id",
                        column: x => x.Servicio_id,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comisiones_Servicios_Variaciones_Servicio_Variacion_id",
                        column: x => x.Servicio_Variacion_id,
                        principalTable: "Servicios_Variaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comisiones_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variacion_Detalles",
                columns: table => new
                {
                    Servicio_Variacion_id = table.Column<int>(type: "int", nullable: false),
                    Caracteristica_Opciones_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variacion_Detalles", x => new { x.Servicio_Variacion_id, x.Caracteristica_Opciones_id });
                    table.ForeignKey(
                        name: "FK_Variacion_Detalles_Caracteristicas_Opciones_Caracteristica_Opciones_id",
                        column: x => x.Caracteristica_Opciones_id,
                        principalTable: "Caracteristicas_Opciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variacion_Detalles_Servicios_Variaciones_Servicio_Variacion_id",
                        column: x => x.Servicio_Variacion_id,
                        principalTable: "Servicios_Variaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comision_Id = table.Column<int>(type: "int", nullable: true),
                    Url_imagen_enviada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envios_Comisiones_Comision_Id",
                        column: x => x.Comision_Id,
                        principalTable: "Comisiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Ciudad_id",
                table: "AspNetUsers",
                column: "Ciudad_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristicas_Opciones_Servicio_Caracteristica_Id",
                table: "Caracteristicas_Opciones",
                column: "Servicio_Caracteristica_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Artista_Id",
                table: "Chats",
                column: "Artista_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Usuario_Id",
                table: "Chats",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Pais_id",
                table: "Ciudades",
                column: "Pais_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_Review_Usuario_id",
                table: "Comisiones",
                column: "Review_Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_Servicio_id",
                table: "Comisiones",
                column: "Servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_Servicio_Variacion_id",
                table: "Comisiones",
                column: "Servicio_Variacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_Usuario_id",
                table: "Comisiones",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_Comision_Id",
                table: "Envios",
                column: "Comision_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_Servicios_Ciudades_Ciudad_id",
                table: "Envios_Servicios_Ciudades",
                column: "Ciudad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_Chat_Id",
                table: "Mensajes",
                column: "Chat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Redes_Sociales_Artistas_Artista_id",
                table: "Redes_Sociales_Artistas",
                column: "Artista_id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Artista_id",
                table: "Servicios",
                column: "Artista_id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Estilo_Id",
                table: "Servicios",
                column: "Estilo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Licencia_Id",
                table: "Servicios",
                column: "Licencia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Tecnica_Id",
                table: "Servicios",
                column: "Tecnica_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Formatos_Servicio_id",
                table: "Servicios_Formatos",
                column: "Servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Temas_Servicio_id",
                table: "Servicios_Temas",
                column: "Servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Variaciones_Licencia_Id",
                table: "Servicios_Variaciones",
                column: "Licencia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Variaciones_Servicio_Id",
                table: "Servicios_Variaciones",
                column: "Servicio_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Tarjetas_Usuario_id",
                table: "Usuarios_Tarjetas",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_Review_id",
                table: "Valoraciones",
                column: "Review_id");

            migrationBuilder.CreateIndex(
                name: "IX_Variacion_Detalles_Caracteristica_Opciones_id",
                table: "Variacion_Detalles",
                column: "Caracteristica_Opciones_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Envios_Servicios_Ciudades");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Redes_Sociales_Artistas");

            migrationBuilder.DropTable(
                name: "Servicios_Formatos");

            migrationBuilder.DropTable(
                name: "Servicios_Temas");

            migrationBuilder.DropTable(
                name: "Usuarios_Tarjetas");

            migrationBuilder.DropTable(
                name: "Valoraciones");

            migrationBuilder.DropTable(
                name: "Variacion_Detalles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comisiones");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Formatos");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Caracteristicas_Opciones");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Servicios_Variaciones");

            migrationBuilder.DropTable(
                name: "Redes_Sociales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Servicios_Caracteristicas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Estilos");

            migrationBuilder.DropTable(
                name: "Licencias");

            migrationBuilder.DropTable(
                name: "Tecnicas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
