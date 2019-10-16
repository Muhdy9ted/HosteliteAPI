using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HosteliteAPI.Migrations
{
    public partial class InitialHostelModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hostels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HostelName = table.Column<string>(maxLength: 50, nullable: false),
                    HostelAddress = table.Column<string>(maxLength: 100, nullable: false),
                    HostelLocation = table.Column<string>(maxLength: 50, nullable: false),
                    HostelType = table.Column<string>(maxLength: 50, nullable: false),
                    HostelNumberOfRooms = table.Column<int>(nullable: false),
                    HostelDescription = table.Column<string>(maxLength: 500, nullable: false),
                    VacantRoom = table.Column<bool>(nullable: false),
                    HostelSlug = table.Column<string>(maxLength: 200, nullable: true),
                    RentPerRoom = table.Column<double>(nullable: false),
                    CreatedHostel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hostels");
        }
    }
}
