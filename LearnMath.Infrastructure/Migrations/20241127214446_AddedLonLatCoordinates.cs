using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnMath.Infrastructure.Migrations
{
    public partial class AddedLonLatCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Addreses",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Addreses",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Addreses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Addreses");
        }
    }
}
