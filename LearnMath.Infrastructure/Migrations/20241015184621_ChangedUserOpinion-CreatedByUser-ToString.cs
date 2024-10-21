using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnMath.Infrastructure.Migrations
{
    public partial class ChangedUserOpinionCreatedByUserToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Users_CreatedByUserId",
                table: "Opinions");

            migrationBuilder.DropIndex(
                name: "IX_Opinions_CreatedByUserId",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Opinions");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Opinions");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Opinions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_CreatedByUserId",
                table: "Opinions",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Users_CreatedByUserId",
                table: "Opinions",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
