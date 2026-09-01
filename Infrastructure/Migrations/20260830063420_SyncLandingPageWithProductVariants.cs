using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyReach_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncLandingPageWithProductVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "LandingPage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "HeroTitle",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "HeroSubtitle",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroImageUrl",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CallToActionUrl",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CallToActionText",
                table: "LandingPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OfferPrice",
                table: "LandingPage",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "LandingPage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "ShowDirectCheckoutForm",
                table: "LandingPage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowWhatsAppButton",
                table: "LandingPage",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "OfferPrice",
                table: "LandingPage");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "LandingPage");

            migrationBuilder.DropColumn(
                name: "ShowDirectCheckoutForm",
                table: "LandingPage");

            migrationBuilder.DropColumn(
                name: "ShowWhatsAppButton",
                table: "LandingPage");

            migrationBuilder.RenameTable(
                name: "LandingPage",
                newName: "LandingPages");

            migrationBuilder.RenameIndex(
                name: "IX_LandingPage_Slug",
                table: "LandingPages",
                newName: "IX_LandingPages_Slug");

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "LandingPages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "LandingPages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "LandingPages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "HeroTitle",
                table: "LandingPages",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HeroSubtitle",
                table: "LandingPages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroImageUrl",
                table: "LandingPages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CallToActionUrl",
                table: "LandingPages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CallToActionText",
                table: "LandingPages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LandingPages",
                table: "LandingPages",
                column: "Id");
        }
    }
}
