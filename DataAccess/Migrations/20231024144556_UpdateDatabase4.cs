using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Services_ServiceId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ServiceId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "OrderDetails",
                newName: "StoreServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_StoreServiceId",
                table: "OrderDetails",
                column: "StoreServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_StoreServices_StoreServiceId",
                table: "OrderDetails",
                column: "StoreServiceId",
                principalTable: "StoreServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_StoreServices_StoreServiceId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_StoreServiceId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "StoreServiceId",
                table: "OrderDetails",
                newName: "ServiceId");

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
    }
}
