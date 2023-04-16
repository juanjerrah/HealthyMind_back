using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Humor.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialHumor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    PermiteVisualizacao = table.Column<bool>(type: "boolean", nullable: false),
                    TipoHumor = table.Column<int>(type: "integer", nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humores");
        }
    }
}
