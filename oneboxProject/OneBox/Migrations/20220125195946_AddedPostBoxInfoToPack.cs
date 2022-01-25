using Microsoft.EntityFrameworkCore.Migrations;

namespace OneBox.Migrations
{
    public partial class AddedPostBoxInfoToPack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostBoxId",
                table: "Packs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packs_PostBoxId",
                table: "Packs",
                column: "PostBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packs_PostBoxes_PostBoxId",
                table: "Packs",
                column: "PostBoxId",
                principalTable: "PostBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packs_PostBoxes_PostBoxId",
                table: "Packs");

            migrationBuilder.DropIndex(
                name: "IX_Packs_PostBoxId",
                table: "Packs");

            migrationBuilder.DropColumn(
                name: "PostBoxId",
                table: "Packs");
        }
    }
}
