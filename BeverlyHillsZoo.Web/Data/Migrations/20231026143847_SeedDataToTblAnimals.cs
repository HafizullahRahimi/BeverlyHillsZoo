using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTblAnimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Animals] ON \r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (1, N'Cheetah', 0, 2, NULL, 120, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (2, N'Lion', 0, 2, NULL, 80, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (3, N'Giraffe', 0, 2, NULL, 50, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (4, N'Elephant', 0, 2, NULL, 20, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (5, N'Seal', 0, 3, NULL, NULL, 10)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (6, N'Shark', 0, 3, NULL, NULL, 30)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (7, N'Seahorse', 0, 3, NULL, NULL, 70)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (8, N'Walrus', 0, 3, NULL, NULL, 18)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (9, N'Colugos', 0, 1, 30, NULL, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (10, N'Sifaka', 0, 1, 33, NULL, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (11, N'Halfbeak', 0, 1, 76, NULL, NULL)\r\nINSERT [dbo].[Animals] ([Id], [Name], [IsDeleted], [Type], [MaxAltitude], [Speed], [DivingDepth]) VALUES (12, N'Flying Fish', 0, 1, 46, NULL, NULL)\r\nSET IDENTITY_INSERT [dbo].[Animals] OFF\r\nGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
