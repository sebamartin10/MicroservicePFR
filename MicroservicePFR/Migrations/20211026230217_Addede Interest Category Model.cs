using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicePFR.Migrations
{
    public partial class AddedeInterestCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestCategory",
                columns: table => new
                {
                    interestCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountOfViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestCategory", x => x.interestCategoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestCategory");
        }
    }
}
