using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofttek.Migrations
{
    public partial class TrabajoIntegradorSofttek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    proyecto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proyecto_nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    proyecto_direccion = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    proyecto_estado = table.Column<int>(type: "int", nullable: false),
                    proyecto_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.proyecto_id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    servicio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servicio_descripcion = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    servicio_estado = table.Column<bool>(type: "bit", nullable: false),
                    servicio_valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    servicio_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.servicio_id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    trabajo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trabajo_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trabajo_idProyecto = table.Column<int>(type: "int", nullable: false),
                    trabajo_idServicio = table.Column<int>(type: "int", nullable: false),
                    trabajo_cantHoras = table.Column<int>(type: "int", nullable: false),
                    trabajo_valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trabajo_costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trabajo_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.trabajo_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuario_dni = table.Column<int>(type: "int", nullable: false),
                    usuario_tipo = table.Column<int>(type: "int", nullable: false),
                    usuario_clave = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuario_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "proyecto_id", "proyecto_activo", "proyecto_direccion", "proyecto_estado", "proyecto_nombre" },
                values: new object[,]
                {
                    { 1, true, "Santa Fe 674, Rio Negro", 1, "Vaca Muerta" },
                    { 2, true, "Cajaraville 1093, Neuquen", 2, "Nueva Nieve" },
                    { 3, true, "Los Ceibos 5732, Chubut", 3, "Salinas Rojas" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "servicio_id", "servicio_activo", "servicio_descripcion", "servicio_estado", "servicio_valorHora" },
                values: new object[,]
                {
                    { 1, true, "Perforacion", true, 500m },
                    { 2, true, "Extraccion", true, 400m },
                    { 3, true, "Transporte", true, 300m }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "trabajo_id", "trabajo_activo", "trabajo_cantHoras", "trabajo_costo", "trabajo_fecha", "trabajo_idProyecto", "trabajo_idServicio", "trabajo_valorHora" },
                values: new object[] { 1, true, 1000, 150000m, new DateTime(2023, 9, 13, 0, 16, 4, 467, DateTimeKind.Local).AddTicks(5924), 1, 1, 150m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuario_id", "usuario_activo", "usuario_clave", "usuario_dni", "usuario_nombre", "usuario_tipo" },
                values: new object[,]
                {
                    { 1, true, "1234", 41826520, "Franco", 1 },
                    { 2, true, "1234", 11824320, "Eliana", 2 },
                    { 3, true, "1234", 42446530, "Juan", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
