using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBox.Migrations
{
    public partial class ParcelLockerAddressChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ParcelLockers",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "ParcelNumber",
                table: "ParcelLockers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParcelNumber",
                table: "ParcelLockers");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "ParcelLockers",
                newName: "Address");
        }
    }
}
