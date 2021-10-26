using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicePFR.Migrations
{
    public partial class AddedFavourite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    articleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.articleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourite");
        }
    }
}
