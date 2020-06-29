using Microsoft.EntityFrameworkCore.Migrations;

namespace DTT_Test.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
