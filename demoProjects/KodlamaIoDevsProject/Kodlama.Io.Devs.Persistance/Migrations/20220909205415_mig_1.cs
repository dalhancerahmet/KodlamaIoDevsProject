using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.Io.Devs.Persistance.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramingLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramingLanguageTechnologies_ProgramingLanguage_ProgramingLanguageId",
                        column: x => x.ProgramingLanguageId,
                        principalTable: "ProgramingLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgramingLanguage",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "ProgramingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[] { 1, "WPF", 1 });

            migrationBuilder.InsertData(
                table: "ProgramingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[] { 2, "ASP.NET", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramingLanguageTechnologies_ProgramingLanguageId",
                table: "ProgramingLanguageTechnologies",
                column: "ProgramingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramingLanguageTechnologies");

            migrationBuilder.DropTable(
                name: "ProgramingLanguage");
        }
    }
}
