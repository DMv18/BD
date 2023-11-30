using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class CursoMaterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoMateriasId",
                table: "CursoMateriasNotas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CursoMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogoMateriaId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoMaterias_CatalogoMateria_CatalogoMateriaId",
                        column: x => x.CatalogoMateriaId,
                        principalTable: "CatalogoMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoMaterias_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoMateriasNotas_CursoMateriasId",
                table: "CursoMateriasNotas",
                column: "CursoMateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoMaterias_CatalogoMateriaId",
                table: "CursoMaterias",
                column: "CatalogoMateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoMaterias_CursoId",
                table: "CursoMaterias",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoMateriasNotas_CursoMaterias_CursoMateriasId",
                table: "CursoMateriasNotas",
                column: "CursoMateriasId",
                principalTable: "CursoMaterias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoMateriasNotas_CursoMaterias_CursoMateriasId",
                table: "CursoMateriasNotas");

            migrationBuilder.DropTable(
                name: "CursoMaterias");

            migrationBuilder.DropIndex(
                name: "IX_CursoMateriasNotas_CursoMateriasId",
                table: "CursoMateriasNotas");

            migrationBuilder.DropColumn(
                name: "CursoMateriasId",
                table: "CursoMateriasNotas");
        }
    }
}
