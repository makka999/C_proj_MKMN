using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace C_proj_MKMN.Data.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "757f2ssc-5321-5454-b865-baabba9f48b1", "2", "User", "USER" },
                    { "b2461abb-d772-adb3-caba-89a58cb66c30", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "757f2ssc-5321-5454-b865-baabba9f48b1", "4c0331ea-76af-4c3c-b985-911653053c0a" },
                    { "b2461abb-d772-adb3-caba-89a58cb66c30", "e6e2f41d-9c07-488e-9d0f-ecfa25c4545c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757f2ssc-5321-5454-b865-baabba9f48b1", "4c0331ea-76af-4c3c-b985-911653053c0a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2461abb-d772-adb3-caba-89a58cb66c30", "e6e2f41d-9c07-488e-9d0f-ecfa25c4545c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757f2ssc-5321-5454-b865-baabba9f48b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2461abb-d772-adb3-caba-89a58cb66c30");
        }
    }
}
