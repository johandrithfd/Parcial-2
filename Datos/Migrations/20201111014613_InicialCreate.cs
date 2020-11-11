using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    CreditoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorCredito = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.CreditoId);
                });

            migrationBuilder.CreateTable(
                name: "Abonos",
                columns: table => new
                {
                    AbonoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorAbono = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    CreditoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonos", x => x.AbonoId);
                    table.ForeignKey(
                        name: "FK_Abonos_Creditos_CreditoId",
                        column: x => x.CreditoId,
                        principalTable: "Creditos",
                        principalColumn: "CreditoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CantidadTrabajadores = table.Column<int>(type: "int", nullable: false),
                    ValorActivos = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    CreditoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresas_Creditos_CreditoId",
                        column: x => x.CreditoId,
                        principalTable: "Creditos",
                        principalColumn: "CreditoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonos_CreditoId",
                table: "Abonos",
                column: "CreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CreditoId",
                table: "Empresas",
                column: "CreditoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Creditos");
        }
    }
}
