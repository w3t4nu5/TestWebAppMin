using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebAppMin.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class missedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CategoryId",
                table: "Purchase",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Categories_CategoryId",
                table: "Purchase",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Categories_CategoryId",
                table: "Purchase");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CategoryId",
                table: "Purchase");
        }
    }
}
