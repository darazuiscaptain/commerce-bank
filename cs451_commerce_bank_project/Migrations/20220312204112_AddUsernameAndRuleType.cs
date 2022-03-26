using Microsoft.EntityFrameworkCore.Migrations;

namespace cs451_commerce_bank_project.Migrations
{
    public partial class AddUsernameAndRuleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "NotificationRules",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "NotificationRules");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "EmailAddress");
        }
    }
}
