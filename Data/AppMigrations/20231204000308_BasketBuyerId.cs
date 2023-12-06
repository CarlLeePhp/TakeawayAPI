using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeawayAPI.Data.AppMigrations
{
    public partial class BasketBuyerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "221ab9d4-bcdc-475a-a5dd-76a7915bf815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df0bcc96-2cf4-4f39-bde5-cdc10655d607");

            migrationBuilder.RenameColumn(
                name: "ByerId",
                table: "Basket",
                newName: "BuyerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "872b0ce3-6471-468c-ad15-1ca933c5bcb7", "f3625517-3717-41d6-a62f-61e58749c002", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "997be29c-48f0-4bd3-93e9-ac9f0bb3583f", "3cec4ca9-6491-42ae-9050-9b7b7f46da8f", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "872b0ce3-6471-468c-ad15-1ca933c5bcb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "997be29c-48f0-4bd3-93e9-ac9f0bb3583f");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Basket",
                newName: "ByerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "221ab9d4-bcdc-475a-a5dd-76a7915bf815", "745712b0-88c5-48f6-878e-3c09fdb798a9", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df0bcc96-2cf4-4f39-bde5-cdc10655d607", "9473ee66-062f-4c31-b689-2c5ceee77602", "Customer", "CUSTOMER" });
        }
    }
}
