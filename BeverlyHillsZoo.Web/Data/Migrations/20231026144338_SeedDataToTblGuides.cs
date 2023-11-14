using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTblGuides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Guides] ON \r\nINSERT [dbo].[Guides] ([Id], [Name], [CompetenceType], [IsDeleted]) VALUES (1, N'Tate Wheeler', 1, 0)\r\nINSERT [dbo].[Guides] ([Id], [Name], [CompetenceType], [IsDeleted]) VALUES (2, N'Olivia Maynard', 2, 0)\r\nINSERT [dbo].[Guides] ([Id], [Name], [CompetenceType], [IsDeleted]) VALUES (3, N'Victor Greer', 3, 0)\r\nSET IDENTITY_INSERT [dbo].[Guides] OFF\r\nGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
