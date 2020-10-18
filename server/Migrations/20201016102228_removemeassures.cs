using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.API.Migrations
{
    public partial class removemeassures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meassures_Products_ProductId",
                table: "Meassures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meassures",
                table: "Meassures");

            migrationBuilder.DropIndex(
                name: "IX_Meassures_ProductId",
                table: "Meassures");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Meassures");

            migrationBuilder.RenameTable(
                name: "Meassures",
                newName: "Meassure");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meassure",
                table: "Meassure",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Meassure",
                table: "Meassure");

            migrationBuilder.RenameTable(
                name: "Meassure",
                newName: "Meassures");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Meassures",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meassures",
                table: "Meassures",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Meassures_ProductId",
                table: "Meassures",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meassures_Products_ProductId",
                table: "Meassures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
