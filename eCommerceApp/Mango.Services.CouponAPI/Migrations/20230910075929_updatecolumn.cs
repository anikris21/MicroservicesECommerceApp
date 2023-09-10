using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DicountAmount",
                table: "Coupons",
                newName: "DiscountAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Coupons",
                newName: "DicountAmount");
        }
    }
}
