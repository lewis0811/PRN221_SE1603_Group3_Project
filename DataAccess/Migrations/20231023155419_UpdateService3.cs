using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateService3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_OrderDetails_OrderDetailId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_OrderDetailId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceId",
                table: "OrderDetails",
                column: "ServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Services_ServiceId",
                table: "OrderDetails",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Services_ServiceId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ServiceId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_OrderDetailId",
                table: "Services",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_OrderDetails_OrderDetailId",
                table: "Services",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
