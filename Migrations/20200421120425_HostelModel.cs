using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HosteliteAPI.Migrations
{
    public partial class HostelModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HostelID",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hostels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HostelName = table.Column<string>(nullable: true),
                    HostelAddress = table.Column<string>(nullable: true),
                    HostelLocation = table.Column<string>(nullable: true),
                    HostelType = table.Column<string>(nullable: true),
                    HostelNumberOfRooms = table.Column<int>(nullable: false),
                    HostelDescription = table.Column<string>(nullable: true),
                    VacantRoom = table.Column<bool>(nullable: false),
                    HostelSlug = table.Column<string>(nullable: true),
                    RentPerRoom = table.Column<double>(nullable: false),
                    CreatedHostel = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hostels_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HostelID",
                table: "Photos",
                column: "HostelID");

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_userId",
                table: "Hostels",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Hostels_HostelID",
                table: "Photos",
                column: "HostelID",
                principalTable: "Hostels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Hostels_HostelID",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Hostels");

            migrationBuilder.DropIndex(
                name: "IX_Photos_HostelID",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "HostelID",
                table: "Photos");
        }
    }
}
