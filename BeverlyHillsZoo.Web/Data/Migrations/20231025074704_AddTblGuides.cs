using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddTblGuides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetenceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_GuideId",
                table: "Visits",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Guides_GuideId",
                table: "Visits",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Guides_GuideId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropIndex(
                name: "IX_Visits_GuideId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Visits");
        }
    }
}
