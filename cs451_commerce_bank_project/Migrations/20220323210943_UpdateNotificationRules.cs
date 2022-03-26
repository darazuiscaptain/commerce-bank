using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cs451_commerce_bank_project.Migrations
{
    public partial class UpdateNotificationRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "NotificationRules");

            migrationBuilder.RenameColumn(
                name: "TimeFrame",
                table: "NotificationRules",
                newName: "Name");

            migrationBuilder.AddColumn<double>(
                name: "AmountEquals",
                table: "NotificationRules",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AmountGreaterThan",
                table: "NotificationRules",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AmountLessThan",
                table: "NotificationRules",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CountTriggered",
                table: "NotificationRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "NotificationRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "NotificationRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountEquals",
                table: "NotificationRules");

            migrationBuilder.DropColumn(
                name: "AmountGreaterThan",
                table: "NotificationRules");

            migrationBuilder.DropColumn(
                name: "AmountLessThan",
                table: "NotificationRules");

            migrationBuilder.DropColumn(
                name: "CountTriggered",
                table: "NotificationRules");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "NotificationRules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "NotificationRules");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "NotificationRules",
                newName: "TimeFrame");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "NotificationRules",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
