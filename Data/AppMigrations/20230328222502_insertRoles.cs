using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeawayAPI.Data.AppMigrations
{
    public partial class insertRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e3dff63-3254-4595-860b-6694140a6762", "3fc741df-cb55-4da5-a624-275878cba1dd", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b52aa3e7-d34f-4777-a509-6ac881ca3c41", "7e8d497e-00ee-4db5-87ac-a5c574b81bae", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3dff63-3254-4595-860b-6694140a6762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b52aa3e7-d34f-4777-a509-6ac881ca3c41");
        }
    }
}
