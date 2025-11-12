using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StackOverflowClone.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    PostedBy = table.Column<string>(type: "TEXT", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    PostedBy = table.Column<string>(type: "TEXT", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Body", "PostedBy", "PostedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Can someone explain the basics of ASP.NET Core?", "Alice", new DateTime(2025, 11, 11, 16, 49, 4, 547, DateTimeKind.Local).AddTicks(3545), "What is ASP.NET Core?" },
                    { 2, "I want to understand EF Core with SQLite.", "Bob", new DateTime(2025, 11, 11, 16, 49, 4, 547, DateTimeKind.Local).AddTicks(3547), "How does EF Core work?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Body", "PostedBy", "PostedDate", "QuestionId" },
                values: new object[,]
                {
                    { 1, "ASP.NET Core is a cross-platform web framework.", "Charlie", new DateTime(2025, 11, 11, 16, 49, 4, 547, DateTimeKind.Local).AddTicks(3631), 1 },
                    { 2, "EF Core maps C# classes to database tables.", "Dave", new DateTime(2025, 11, 11, 16, 49, 4, 547, DateTimeKind.Local).AddTicks(3633), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
