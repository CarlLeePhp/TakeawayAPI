using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeawayAPI.Data.AppMigrations
{
    public partial class adDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3dff63-3254-4595-860b-6694140a6762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b52aa3e7-d34f-4777-a509-6ac881ca3c41");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    MyProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "500fc115-4365-4a67-85bd-9f8daec66264", "b339f319-0908-4956-b13d-bea905b00242", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccc43c28-43c2-400b-bfba-2bc77a4ccaa6", "55a2cea9-9898-42d9-b563-373facc05ff8", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CategoryId",
                table: "Dish",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "500fc115-4365-4a67-85bd-9f8daec66264");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccc43c28-43c2-400b-bfba-2bc77a4ccaa6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e3dff63-3254-4595-860b-6694140a6762", "3fc741df-cb55-4da5-a624-275878cba1dd", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b52aa3e7-d34f-4777-a509-6ac881ca3c41", "7e8d497e-00ee-4db5-87ac-a5c574b81bae", "Customer", "CUSTOMER" });
        }
    }
}
