using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class CatalogoDesarrollo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogoDesarrolloId",
                table: "CatalogoCurricular",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CatalogoDesarrollo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoDesarrollo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoCurricular_CatalogoDesarrolloId",
                table: "CatalogoCurricular",
                column: "CatalogoDesarrolloId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogoCurricular_CatalogoDesarrollo_CatalogoDesarrolloId",
                table: "CatalogoCurricular",
                column: "CatalogoDesarrolloId",
                principalTable: "CatalogoDesarrollo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogoCurricular_CatalogoDesarrollo_CatalogoDesarrolloId",
                table: "CatalogoCurricular");

            migrationBuilder.DropTable(
                name: "CatalogoDesarrollo");

            migrationBuilder.DropIndex(
                name: "IX_CatalogoCurricular_CatalogoDesarrolloId",
                table: "CatalogoCurricular");

            migrationBuilder.DropColumn(
                name: "CatalogoDesarrolloId",
                table: "CatalogoCurricular");
        }
    }
}
