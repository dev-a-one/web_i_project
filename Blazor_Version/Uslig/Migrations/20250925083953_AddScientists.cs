using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uslig.Migrations
{
    /// <inheritdoc />
    public partial class AddScientists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scientist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scientist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientistAlmaMater",
                columns: table => new
                {
                    ScientistId = table.Column<int>(type: "INTEGER", nullable: false),
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientistAlmaMater", x => new { x.ScientistId, x.UniversityId });
                    table.ForeignKey(
                        name: "FK_ScientistAlmaMater_Scientist_ScientistId",
                        column: x => x.ScientistId,
                        principalTable: "Scientist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientistAlmaMater_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScientistAlmaMater_UniversityId",
                table: "ScientistAlmaMater",
                column: "UniversityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScientistAlmaMater");

            migrationBuilder.DropTable(
                name: "Scientist");
        }
    }
}
