using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace POC_TMB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cliente = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Produto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Cliente", "DataCriacao", "Produto", "Status", "Valor" },
                values: new object[,]
                {
                    { new Guid("8a7b6f5c-0e3d-4c1b-9d7a-1b2c3d4e5f6a"), "Matheus Siqueira", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Teste Tmb", "Pendente", 1000m },
                    { new Guid("f4a3e2d1-c0b9-4a8e-9d6c-5b4a3c2d1e0f"), "Julia Gomyde", new DateTime(2024, 1, 2, 14, 30, 0, 0, DateTimeKind.Utc), "Teste Tmb", "Concluido", 1500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
