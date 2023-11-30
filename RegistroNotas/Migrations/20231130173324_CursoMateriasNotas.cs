using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class CursoMateriasNotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CursoMateriasNotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoMateriasNotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoMateriasNotas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DocenteId",
                table: "Cursos",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoMateriasNotas_CursoId",
                table: "CursoMateriasNotas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Docente_DocenteId",
                table: "Cursos",
                column: "DocenteId",
                principalTable: "Docente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Docente_DocenteId",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "CursoMateriasNotas");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_DocenteId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Cursos");
        }
    }
}
