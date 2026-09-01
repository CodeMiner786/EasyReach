using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyReach_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLandingPageProductsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandingPage_Products_ProductId",
                table: "LandingPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LandingPage",
                table: "LandingPage");

            migrationBuilder.DropIndex(
                name: "IX_LandingPage_ProductId",
                table: "LandingPage");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "LandingPage");

            migrationBuilder.RenameTable(
                name: "LandingPage",
                newName: "LandingPages");

            migrationBuilder.RenameIndex(
                name: "IX_LandingPage_Slug",
                table: "LandingPages",
                newName: "IX_LandingPages_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LandingPages",
                table: "LandingPages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LandingPageProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandingPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomOfferPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPageProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandingPageProducts_LandingPages_LandingPageId",
                        column: x => x.LandingPageId,
                        principalTable: "LandingPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandingPageProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandingPageProducts_LandingPageId",
                table: "LandingPageProducts",
                column: "LandingPageId");

            migrationBuilder.CreateIndex(
                name: "IX_LandingPageProducts_ProductId",
                table: "LandingPageProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandingPageProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LandingPages",
                table: "LandingPages");

            migrationBuilder.RenameTable(
                name: "LandingPages",
                newName: "LandingPage");

            migrationBuilder.RenameIndex(
                name: "IX_LandingPages_Slug",
                table: "LandingPage",
                newName: "IX_LandingPage_Slug");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "LandingPage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LandingPage",
                table: "LandingPage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LandingPage_ProductId",
                table: "LandingPage",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandingPage_Products_ProductId",
                table: "LandingPage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
