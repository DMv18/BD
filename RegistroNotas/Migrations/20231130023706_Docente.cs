using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class Docente : Migration
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
                name: "Docente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Primer_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Segundo_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Primer_Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Segundo_Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DocenteId",
                table: "Cursos",
                column: "DocenteId");

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
                name: "Docente");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_DocenteId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Cursos");
        }
    }
}
