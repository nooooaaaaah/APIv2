using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIv2.Migrations
{
    public partial class sfDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Task",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TaskDescription",
                table: "Task",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "Event",
                newName: "RecurrenceRule");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAllDay",
                table: "Event",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceException",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceID",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "IsAllDay",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "RecurrenceException",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "RecurrenceID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Task",
                newName: "TaskName");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Task",
                newName: "TaskDescription");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "RecurrenceRule",
                table: "Event",
                newName: "EventDescription");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
