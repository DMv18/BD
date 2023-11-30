using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class CatalogoCurricular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogoMateria_CursoMaterias_CursoMateriasId",
                table: "CatalogoMateria");

            migrationBuilder.DropIndex(
                name: "IX_CatalogoMateria_CursoMateriasId",
                table: "CatalogoMateria");

            migrationBuilder.DropColumn(
                name: "CursoMateriasId",
                table: "CatalogoMateria");

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

            migrationBuilder.CreateTable(
                name: "CatalogoCurricular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CatalogoDesarrolloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoCurricular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogoCurricular_CatalogoDesarrollo_CatalogoDesarrolloId",
                        column: x => x.CatalogoDesarrolloId,
                        principalTable: "CatalogoDesarrollo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoCurricular_CatalogoDesarrolloId",
                table: "CatalogoCurricular",
                column: "CatalogoDesarrolloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoCurricular");

            migrationBuilder.DropTable(
                name: "CatalogoDesarrollo");

            migrationBuilder.AddColumn<int>(
                name: "CursoMateriasId",
                table: "CatalogoMateria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoMateria_CursoMateriasId",
                table: "CatalogoMateria",
                column: "CursoMateriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogoMateria_CursoMaterias_CursoMateriasId",
                table: "CatalogoMateria",
                column: "CursoMateriasId",
                principalTable: "CursoMaterias",
                principalColumn: "Id");
        }
    }
}
