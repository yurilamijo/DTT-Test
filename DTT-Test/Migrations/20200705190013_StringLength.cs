using Microsoft.EntityFrameworkCore.Migrations;

namespace DTT_Test.Migrations
{
    public partial class StringLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Article",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150) CHARACTER SET utf8mb4",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Article",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(225) CHARACTER SET utf8mb4",
                oldMaxLength: 225);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Article",
                type: "varchar(150) CHARACTER SET utf8mb4",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Article",
                type: "varchar(225) CHARACTER SET utf8mb4",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
