using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Gardens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gardens");
        }
    }
}
