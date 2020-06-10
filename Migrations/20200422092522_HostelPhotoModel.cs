using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HosteliteAPI.Migrations
{
    public partial class HostelPhotoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Hostels_HostelID",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_HostelID",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "HostelID",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "HostelPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    HostelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostelPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostelPhotos_Hostels_HostelID",
                        column: x => x.HostelID,
                        principalTable: "Hostels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HostelPhotos_HostelID",
                table: "HostelPhotos",
                column: "HostelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostelPhotos");

            migrationBuilder.AddColumn<int>(
                name: "HostelID",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HostelID",
                table: "Photos",
                column: "HostelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Hostels_HostelID",
                table: "Photos",
                column: "HostelID",
                principalTable: "Hostels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
