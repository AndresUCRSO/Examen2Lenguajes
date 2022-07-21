using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegundoParcial.Migrations
{
    public partial class addAvailableSpaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSpaces",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSpaces",
                table: "Event");
        }
    }
}
