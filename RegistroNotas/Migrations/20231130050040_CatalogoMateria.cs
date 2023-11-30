using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class CatalogoMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoMaterias_CursoMateriasNotas_CursoMateriasNotasId",
                table: "CursoMaterias");

            migrationBuilder.DropIndex(
                name: "IX_CursoMaterias_CursoMateriasNotasId",
                table: "CursoMaterias");

            migrationBuilder.DropColumn(
                name: "CursoMateriasNotasId",
                table: "CursoMaterias");

            migrationBuilder.CreateTable(
                name: "CatalogoMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Parciales = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    CursoMateriasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogoMateria_CursoMaterias_CursoMateriasId",
                        column: x => x.CursoMateriasId,
                        principalTable: "CursoMaterias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CatalogoMateria_Docente_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoMateria_CursoMateriasId",
                table: "CatalogoMateria",
                column: "CursoMateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoMateria_DocenteId",
                table: "CatalogoMateria",
                column: "DocenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoMateria");

            migrationBuilder.AddColumn<int>(
                name: "CursoMateriasNotasId",
                table: "CursoMaterias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CursoMaterias_CursoMateriasNotasId",
                table: "CursoMaterias",
                column: "CursoMateriasNotasId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoMaterias_CursoMateriasNotas_CursoMateriasNotasId",
                table: "CursoMaterias",
                column: "CursoMateriasNotasId",
                principalTable: "CursoMateriasNotas",
                principalColumn: "Id");
        }
    }
}
