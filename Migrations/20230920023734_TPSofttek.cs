using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofttek.Migrations
{
    public partial class TPSofttek : Migration
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
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
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
                name: "Usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuario_dni = table.Column<int>(type: "int", nullable: false),
                    usuario_cuil = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    usuario_clave = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    usuario_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    trabajo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trabajo_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    proyecto_id = table.Column<int>(type: "int", nullable: false),
                    servicio_id = table.Column<int>(type: "int", nullable: false),
                    trabajo_cantHoras = table.Column<int>(type: "int", nullable: false),
                    trabajo_valorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trabajo_costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trabajo_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.trabajo_id);
                    table.ForeignKey(
                        name: "FK_Trabajos_Proyectos_proyecto_id",
                        column: x => x.proyecto_id,
                        principalTable: "Proyectos",
                        principalColumn: "proyecto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Servicios_servicio_id",
                        column: x => x.servicio_id,
                        principalTable: "Servicios",
                        principalColumn: "servicio_id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Roles",
                columns: new[] { "role_id", "role_activo", "role_description", "role_name" },
                values: new object[,]
                {
                    { 1, true, "Admin", "Admin" },
                    { 2, true, "Consulta", "Consulta" }
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
                columns: new[] { "trabajo_id", "trabajo_activo", "trabajo_cantHoras", "trabajo_costo", "trabajo_fecha", "proyecto_id", "servicio_id", "trabajo_valorHora" },
                values: new object[] { 1, true, 1000, 150000m, new DateTime(2023, 9, 19, 23, 37, 34, 158, DateTimeKind.Local).AddTicks(7746), 1, 1, 150m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuario_id", "usuario_activo", "usuario_clave", "usuario_cuil", "usuario_dni", "usuario_nombre", "role_id" },
                values: new object[,]
                {
                    { 1, true, "241b56ebb2e452dfa1d6c172fb66e95722442d6097e1d62e6705e3dc1f3bff53", 20418265206L, 41826520, "Franco", 1 },
                    { 2, true, "2aa98a180fa531837a47595f8128731e0364baab83703c0c19548afb7fce58ff", 27118243201L, 11824320, "Eliana", 2 },
                    { 3, true, "08f475f7eda6dfc3934f3e34873ec2f08f532ff526eec24c84a2cbe2355d78b4", 20424465306L, 42446530, "Juan", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_proyecto_id",
                table: "Trabajos",
                column: "proyecto_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_servicio_id",
                table: "Trabajos",
                column: "servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_role_id",
                table: "Usuarios",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
