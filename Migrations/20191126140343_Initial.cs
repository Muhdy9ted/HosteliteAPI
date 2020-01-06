using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HosteliteAPI.Migrations
{
    public partial class Initial : Migration
    {
        /// <summary>
        /// database migration
        /// </summary>
        /// <returns></returns>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CreatedHostel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <summary>
        /// database migration
        /// </summary>
        /// <returns></returns>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hostels");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
