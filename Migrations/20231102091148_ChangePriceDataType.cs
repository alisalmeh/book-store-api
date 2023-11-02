using Microsoft.EntityFrameworkCore.Migrations;

namespace AliBookStoreApi.Migrations
{
    public partial class ChangePriceDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
