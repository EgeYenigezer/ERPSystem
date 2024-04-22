using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migEm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockDetail_User_RecieverId",
                table: "StockDetail");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "StockDetail",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_StockDetail_RecieverId",
                table: "StockDetail",
                newName: "IX_StockDetail_ReceiverId");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockDetail_User_ReceiverId",
                table: "StockDetail",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockDetail_User_ReceiverId",
                table: "StockDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "StockDetail",
                newName: "RecieverId");

            migrationBuilder.RenameIndex(
                name: "IX_StockDetail_ReceiverId",
                table: "StockDetail",
                newName: "IX_StockDetail_RecieverId");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_StockDetail_User_RecieverId",
                table: "StockDetail",
                column: "RecieverId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
