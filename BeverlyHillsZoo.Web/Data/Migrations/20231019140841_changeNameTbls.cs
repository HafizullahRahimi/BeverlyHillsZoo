using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    /// <inheritdoc />
    public partial class changeNameTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_visitors",
                table: "visitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_animals",
                table: "animals");

            migrationBuilder.RenameTable(
                name: "visitors",
                newName: "Visitors");

            migrationBuilder.RenameTable(
                name: "animals",
                newName: "Animals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visitors",
                table: "Visitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Visitors",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Visitors",
                newName: "visitors");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "animals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visitors",
                table: "visitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_animals",
                table: "animals",
                column: "Id");
        }
    }
}
