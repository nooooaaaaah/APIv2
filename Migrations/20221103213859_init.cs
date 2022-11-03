using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustomerEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustomerAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.GardenId);
                    table.ForeignKey(
                        name: "FK_Garden_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garden_UserId",
                table: "Garden",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
