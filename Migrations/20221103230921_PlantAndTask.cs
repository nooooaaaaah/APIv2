using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class PlantAndTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "GardenID",
                table: "Gardens",
                newName: "GardenId");

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantVariety = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GardenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.PlantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.RenameColumn(
                name: "GardenId",
                table: "Gardens",
                newName: "GardenID");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_User_UserId",
                table: "Gardens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
