using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlifTj.DataAccess.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceProduct",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Persent",
                table: "Products",
                newName: "Percent");

            migrationBuilder.RenameColumn(
                name: "Persent",
                table: "Orders",
                newName: "MonthKredit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Percent",
                table: "Products",
                newName: "Persent");

            migrationBuilder.RenameColumn(
                name: "MonthKredit",
                table: "Orders",
                newName: "Persent");

            migrationBuilder.AddColumn<double>(
                name: "PriceProduct",
                table: "Orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
