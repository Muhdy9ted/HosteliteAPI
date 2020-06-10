using Microsoft.EntityFrameworkCore.Migrations;

namespace HosteliteAPI.Migrations
{
    public partial class addedPublicID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicID",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicID",
                table: "HostelPhotos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicID",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PublicID",
                table: "HostelPhotos");
        }
    }
}
