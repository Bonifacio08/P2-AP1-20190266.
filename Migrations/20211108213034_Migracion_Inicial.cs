using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_20190266.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    Proyectoid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.Proyectoid);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeTarea",
                columns: table => new
                {
                    Tipoid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipodeTarea = table.Column<string>(type: "TEXT", nullable: true),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeTarea", x => x.Tipoid);
                });

            migrationBuilder.CreateTable(
                name: "TipoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Proyectoid = table.Column<int>(type: "INTEGER", nullable: false),
                    TipodeTarea = table.Column<string>(type: "TEXT", nullable: true),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoDetalle_Proyecto_Proyectoid",
                        column: x => x.Proyectoid,
                        principalTable: "Proyecto",
                        principalColumn: "Proyectoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "Tipoid", "Requerimiento", "Tiempo", "TipodeTarea" },
                values: new object[] { 1, " ", 0, "Analisis" });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "Tipoid", "Requerimiento", "Tiempo", "TipodeTarea" },
                values: new object[] { 2, "Hacer un diseno excelente", 0, "Diseno" });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "Tipoid", "Requerimiento", "Tiempo", "TipodeTarea" },
                values: new object[] { 3, "Programar todo el registro", 0, "Programacion" });

            migrationBuilder.InsertData(
                table: "TipoDeTarea",
                columns: new[] { "Tipoid", "Requerimiento", "Tiempo", "TipodeTarea" },
                values: new object[] { 4, "Probar con mucho cuidado", 0, "Prueba" });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDetalle_Proyectoid",
                table: "TipoDetalle",
                column: "Proyectoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDetalle");

            migrationBuilder.DropTable(
                name: "TipoDeTarea");

            migrationBuilder.DropTable(
                name: "Proyecto");
        }
    }
}
