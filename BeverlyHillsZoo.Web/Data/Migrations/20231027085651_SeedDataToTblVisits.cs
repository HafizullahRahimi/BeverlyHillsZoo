using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTblVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Visits] ON \r\nINSERT [dbo].[Visits] ([Id], [NumberOfVisitor], [VisitDate], [IsVisited], [AtMorning], [AtAfternoon], [AnimalId], [VisitorId], [GuideId]) VALUES (1, 1, CAST(N'2023-10-25T00:00:00.0000000' AS DateTime2), 0, 0, 1, 7, 1, 3)\r\nINSERT [dbo].[Visits] ([Id], [NumberOfVisitor], [VisitDate], [IsVisited], [AtMorning], [AtAfternoon], [AnimalId], [VisitorId], [GuideId]) VALUES (2, 1, CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2), 0, 1, 0, 12, 2, 1)\r\nINSERT [dbo].[Visits] ([Id], [NumberOfVisitor], [VisitDate], [IsVisited], [AtMorning], [AtAfternoon], [AnimalId], [VisitorId], [GuideId]) VALUES (3, 11, CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2), 0, 1, 1, 11, 1, 1)\r\nINSERT [dbo].[Visits] ([Id], [NumberOfVisitor], [VisitDate], [IsVisited], [AtMorning], [AtAfternoon], [AnimalId], [VisitorId], [GuideId]) VALUES (4, 1, CAST(N'2023-10-25T00:00:00.0000000' AS DateTime2), 0, 1, 0, 5, 3, 3)\r\nINSERT [dbo].[Visits] ([Id], [NumberOfVisitor], [VisitDate], [IsVisited], [AtMorning], [AtAfternoon], [AnimalId], [VisitorId], [GuideId]) VALUES (5, 1, CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2), 0, 1, 0, 7, 4, 3)\r\nINSERT [dbo].[Visits] ([Id], [NumberOfVisitor], [VisitDate], [IsVisited], [AtMorning], [AtAfternoon], [AnimalId], [VisitorId], [GuideId]) VALUES (6, 1, CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2), 0, 1, 0, 2, 1, 2)\r\nSET IDENTITY_INSERT [dbo].[Visits] OFF\r\nGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
