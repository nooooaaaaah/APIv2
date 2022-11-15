using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class nofixedlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(20)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Task");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "JobId");
        }
    }
}
