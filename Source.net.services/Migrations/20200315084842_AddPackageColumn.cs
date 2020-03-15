using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.net.services.Migrations
{
    public partial class AddPackageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Package",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Package",
                table: "Users");
        }
    }
}
