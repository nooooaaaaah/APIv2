using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TaskDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
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
                    GardenID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.GardenID);
                    table.ForeignKey(
                        name: "FK_Garden_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Calender",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateTime = table.Column<DateTime>(name: "Date/Time", type: "smalldatetime", nullable: true),
                    GardenID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calender", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Calender_Garden",
                        column: x => x.GardenID,
                        principalTable: "Garden",
                        principalColumn: "GardenID");
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantID = table.Column<int>(type: "int", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlantVariety = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlantDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GardenID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantID);
                    table.ForeignKey(
                        name: "FK_Plants_Garden",
                        column: x => x.GardenID,
                        principalTable: "Garden",
                        principalColumn: "GardenID");
                });

            migrationBuilder.CreateTable(
                name: "Calender Task",
                columns: table => new
                {
                    EventTaskID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false),
                    TaskID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calender Task", x => x.EventTaskID);
                    table.ForeignKey(
                        name: "EventID",
                        column: x => x.EventID,
                        principalTable: "Calender",
                        principalColumn: "EventID");
                    table.ForeignKey(
                        name: "TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calender_GardenID",
                table: "Calender",
                column: "GardenID");

            migrationBuilder.CreateIndex(
                name: "IX_Calender Task_EventID",
                table: "Calender Task",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Calender Task_TaskID",
                table: "Calender Task",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Garden_UserID",
                table: "Garden",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GardenID",
                table: "Plants",
                column: "GardenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calender Task");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Calender");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
