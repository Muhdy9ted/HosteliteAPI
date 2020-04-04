using Microsoft.EntityFrameworkCore.Migrations;

namespace HosteliteAPI.Migrations
{
    public partial class userModelhostelModelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLandlord",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Hostels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_userId",
                table: "Hostels",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostels_Users_userId",
                table: "Hostels",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_Users_userId",
                table: "Hostels");

            migrationBuilder.DropIndex(
                name: "IX_Hostels_userId",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "IsLandlord",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Hostels");
        }
    }
}
