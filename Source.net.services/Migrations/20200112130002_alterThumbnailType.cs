using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.net.services.Migrations
{
    public partial class alterThumbnailType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
