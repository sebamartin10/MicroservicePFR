using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicePFR.Migrations
{
    public partial class Profileupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "UserProfile",
                newName: "phoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "UserProfile",
                newName: "name");
        }
    }
}
