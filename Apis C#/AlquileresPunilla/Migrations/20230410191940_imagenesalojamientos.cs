using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlquileresPunilla.Migrations
{
    /// <inheritdoc />
    public partial class imagenesalojamientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "complejos",
                columns: table => new
                {
                    IdComplejo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreComplejo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkFotos = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdComplejo);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "estadoestadia",
                columns: table => new
                {
                    idEstadoEstadia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEstadoEstadia);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "formasdepagos",
                columns: table => new
                {
                    idFormasDePagos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idFormasDePagos);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    idProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idProvincia);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tipospagos",
                columns: table => new
                {
                    idTiposPagos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTiposPagos);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "alojamientos",
                columns: table => new
                {
                    idAlojamientos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdComplejo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    LinkFotos = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idAlojamientos);
                    table.ForeignKey(
                        name: "Fk_complejos",
                        column: x => x.IdComplejo,
                        principalTable: "complejos",
                        principalColumn: "IdComplejo");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsuarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdComplejo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUsuarios);
                    table.ForeignKey(
                        name: "IdComplejo",
                        column: x => x.IdComplejo,
                        principalTable: "complejos",
                        principalColumn: "IdComplejo");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "localidades",
                columns: table => new
                {
                    idLocalidades = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProvicia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idLocalidades);
                    table.ForeignKey(
                        name: "fkPro-Loc",
                        column: x => x.IdProvicia,
                        principalTable: "provincias",
                        principalColumn: "idProvincia");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    idPagos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Importe = table.Column<int>(type: "int", nullable: false),
                    IdTipoPago = table.Column<int>(type: "int", nullable: false),
                    IdFormaPago = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPagos);
                    table.ForeignKey(
                        name: "Fk_forrmasdepago",
                        column: x => x.IdFormaPago,
                        principalTable: "formasdepagos",
                        principalColumn: "idFormasDePagos");
                    table.ForeignKey(
                        name: "Fk_tipoPagos",
                        column: x => x.IdTipoPago,
                        principalTable: "tipospagos",
                        principalColumn: "idTiposPagos");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "imagenesalojamientos",
                columns: table => new
                {
                    idImagenes = table.Column<int>(type: "int", nullable: false),
                    idAlojamiento = table.Column<int>(type: "int", nullable: false),
                    LinkFotos = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idImagenes);
                    table.ForeignKey(
                        name: "fk-img-Alojamiento",
                        column: x => x.idAlojamiento,
                        principalTable: "alojamientos",
                        principalColumn: "idAlojamientos");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    idpersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<sbyte>(type: "tinyint", nullable: false),
                    IdLocalidad = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idpersona);
                    table.ForeignKey(
                        name: "fk_localidad",
                        column: x => x.IdLocalidad,
                        principalTable: "localidades",
                        principalColumn: "idLocalidades");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "estadias",
                columns: table => new
                {
                    NroEstadia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaEgreso = table.Column<DateOnly>(type: "date", nullable: false),
                    CantPersonas = table.Column<int>(type: "int", nullable: false),
                    Desayuno = table.Column<sbyte>(type: "tinyint", nullable: false),
                    ImporteTotal = table.Column<int>(type: "int", nullable: false),
                    IdAlojamiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.NroEstadia);
                    table.ForeignKey(
                        name: "Fk_Alojameinto",
                        column: x => x.IdAlojamiento,
                        principalTable: "alojamientos",
                        principalColumn: "idAlojamientos");
                    table.ForeignKey(
                        name: "Fk_Estado",
                        column: x => x.IdEstado,
                        principalTable: "estadoestadia",
                        principalColumn: "idEstadoEstadia");
                    table.ForeignKey(
                        name: "Fk_Persona",
                        column: x => x.IdPersona,
                        principalTable: "personas",
                        principalColumn: "idpersona");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "detalleestadia",
                columns: table => new
                {
                    idDetalleEstadia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEstadia = table.Column<int>(type: "int", nullable: false),
                    IdPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idDetalleEstadia);
                    table.ForeignKey(
                        name: "Fk_Estadia",
                        column: x => x.IdEstadia,
                        principalTable: "estadias",
                        principalColumn: "NroEstadia");
                    table.ForeignKey(
                        name: "Fk_Pagos",
                        column: x => x.IdPago,
                        principalTable: "pagos",
                        principalColumn: "idPagos");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "Fk_complejos_idx",
                table: "alojamientos",
                column: "IdComplejo");

            migrationBuilder.CreateIndex(
                name: "Fk_Estadia_idx",
                table: "detalleestadia",
                column: "IdEstadia");

            migrationBuilder.CreateIndex(
                name: "Fk_Pagos_idx",
                table: "detalleestadia",
                column: "IdPago");

            migrationBuilder.CreateIndex(
                name: "Fk_Alojameinto_idx",
                table: "estadias",
                column: "IdAlojamiento");

            migrationBuilder.CreateIndex(
                name: "Fk_Estado_idx",
                table: "estadias",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "Fk_Persona_idx",
                table: "estadias",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "fk-img-Alojamiento_idx",
                table: "imagenesalojamientos",
                column: "idAlojamiento");

            migrationBuilder.CreateIndex(
                name: "fkPro-Loc_idx",
                table: "localidades",
                column: "IdProvicia");

            migrationBuilder.CreateIndex(
                name: "Fk_forrmasdepago_idx",
                table: "pagos",
                column: "IdFormaPago");

            migrationBuilder.CreateIndex(
                name: "Fk_tipoPagos_idx",
                table: "pagos",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "fk_localidad_idx",
                table: "personas",
                column: "IdLocalidad");

            migrationBuilder.CreateIndex(
                name: "IdComplejo_idx",
                table: "usuarios",
                column: "IdComplejo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleestadia");

            migrationBuilder.DropTable(
                name: "imagenesalojamientos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "estadias");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "alojamientos");

            migrationBuilder.DropTable(
                name: "estadoestadia");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "formasdepagos");

            migrationBuilder.DropTable(
                name: "tipospagos");

            migrationBuilder.DropTable(
                name: "complejos");

            migrationBuilder.DropTable(
                name: "localidades");

            migrationBuilder.DropTable(
                name: "provincias");
        }
    }
}
