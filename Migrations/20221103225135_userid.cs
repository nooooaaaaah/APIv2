using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Gardens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Gardens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
