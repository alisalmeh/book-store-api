using Microsoft.EntityFrameworkCore.Migrations;

namespace AliBookStoreApi.Migrations
{
    public partial class RenameColumnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Books",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "Amount");
        }
    }
}
