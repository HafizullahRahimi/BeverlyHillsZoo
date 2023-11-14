using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTblVisitors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Visitors] ON \r\nINSERT [dbo].[Visitors] ([Id], [Name], [PersonNumber], [IsDeleted]) VALUES (1, N'Brent Cannon', 197211033944, 0)\r\nINSERT [dbo].[Visitors] ([Id], [Name], [PersonNumber], [IsDeleted]) VALUES (2, N'Carter Kim', 200407312396, 0)\r\nINSERT [dbo].[Visitors] ([Id], [Name], [PersonNumber], [IsDeleted]) VALUES (3, N'Tate Cotton', 200007312376, 0)\r\nINSERT [dbo].[Visitors] ([Id], [Name], [PersonNumber], [IsDeleted]) VALUES (4, N'Willa Rosario', 197711033747, 0)\r\nSET IDENTITY_INSERT [dbo].[Visitors] OFF\r\nGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
