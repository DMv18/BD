using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroNotas.Migrations
{
    /// <inheritdoc />
    public partial class Curso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grado = table.Column<int>(type: "int", nullable: false),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    ModalidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Modalidades_ModalidadId",
                        column: x => x.ModalidadId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursos_Periodos_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ModalidadId",
                table: "Cursos",
                column: "ModalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_PeriodoId",
                table: "Cursos",
                column: "PeriodoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
