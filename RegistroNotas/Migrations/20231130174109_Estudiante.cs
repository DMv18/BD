using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class Estudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "CursoMateriasNotas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Primer_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Segundo_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Primer_Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Segundo_Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoMateriasNotas_EstudianteId",
                table: "CursoMateriasNotas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CursoId",
                table: "Estudiantes",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoMateriasNotas_Estudiantes_EstudianteId",
                table: "CursoMateriasNotas",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoMateriasNotas_Estudiantes_EstudianteId",
                table: "CursoMateriasNotas");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_CursoMateriasNotas_EstudianteId",
                table: "CursoMateriasNotas");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "CursoMateriasNotas");
        }
    }
}
