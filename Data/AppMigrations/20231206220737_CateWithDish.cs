using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeawayAPI.Data.AppMigrations
{
    public partial class CateWithDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "872b0ce3-6471-468c-ad15-1ca933c5bcb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "997be29c-48f0-4bd3-93e9-ac9f0bb3583f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7732456f-62fb-4df5-baf8-94c67a8ad184", "1994d1f6-7818-4d0c-b5e1-f483739b444e", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e146860b-87cd-48c7-818f-c6e4df00019b", "5bfa886a-a83c-4b57-88a4-0cefb6970147", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7732456f-62fb-4df5-baf8-94c67a8ad184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e146860b-87cd-48c7-818f-c6e4df00019b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "872b0ce3-6471-468c-ad15-1ca933c5bcb7", "f3625517-3717-41d6-a62f-61e58749c002", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "997be29c-48f0-4bd3-93e9-ac9f0bb3583f", "3cec4ca9-6491-42ae-9050-9b7b7f46da8f", "Manager", "MANAGER" });
        }
    }
}
