using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Infrastructure.Migrations
{
    public partial class ChangeHotelImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "HotelImage");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "HotelImage",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "HotelImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                table: "HotelImage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "HotelImage");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                table: "HotelImage");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "HotelImage",
                newName: "ImagePath");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "HotelImage",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
