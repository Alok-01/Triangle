using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.API.CompanyEmployees.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65ff206e-6fb0-41e2-b06d-b1f0ec0f8cf6", "3976c3ef-23c7-483d-b3a7-63254b067d01", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f7f659b-9081-492a-a8b2-3ea877a6835a", "40ea99fd-328b-4f74-9512-4ca061df1d04", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f7f659b-9081-492a-a8b2-3ea877a6835a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65ff206e-6fb0-41e2-b06d-b1f0ec0f8cf6");
        }
    }
}
