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
            migrationBuilder.CreateTable(
                name: "CursoMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoId = table.Column<int>(type: "int", nullable: true),
                    CursoMateriasNotasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoMaterias_CursoMateriasNotas_CursoMateriasNotasId",
                        column: x => x.CursoMateriasNotasId,
                        principalTable: "CursoMateriasNotas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CursoMaterias_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoMaterias_CursoId",
                table: "CursoMaterias",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoMaterias_CursoMateriasNotasId",
                table: "CursoMaterias",
                column: "CursoMateriasNotasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoMaterias");
        }
    }
}
