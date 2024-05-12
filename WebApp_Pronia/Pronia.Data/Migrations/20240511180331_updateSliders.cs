using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia.Data.Migrations
{
    public partial class updateSliders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUlr",
                table: "Sliders",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Sliders",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sliders",
                newName: "ImageUlr");
        }
    }
}
