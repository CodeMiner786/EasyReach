using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyReach_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToShippingAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ShippingAddresses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ShippingAddresses");
        }
    }
}
