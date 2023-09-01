using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    public partial class PhoneBookEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PhoneBook",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBook_UserId",
                table: "PhoneBook",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_AspNetUsers_UserId",
                table: "PhoneBook",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_AspNetUsers_UserId",
                table: "PhoneBook");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBook_UserId",
                table: "PhoneBook");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PhoneBook",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
