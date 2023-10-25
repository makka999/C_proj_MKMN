using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace C_proj_MKMN.Data.Migrations
{
    /// <inheritdoc />
    public partial class role3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757f2ssc-5321-5454-b865-baabba9f48b1", "4c0331ea-76af-4c3c-b985-91165307230a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2461abb-d772-adb3-caba-89a58cb66c30", "e6e2f41d-9c07-488e-9d0f-ecfa25c3345c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757f2ssc-5321-5454-b865-baabba9f48b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2461abb-d772-adb3-caba-89a58cb66c30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin123", "1", "Admin", "ADMIN" },
                    { "user123", "2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordIndividualLength", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adminid123", 0, "3580bb76-687d-4a7d-8deb-1bdc8520088d", "admin@admin.admin", true, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", "AQAAAAIAAYagAAAAECX/MwHytrbuUjtIoRP4L36ISgg2OYOTc4lC8/CqI8tRlHAw39znDfI8T33dXObNKg==", 10, null, false, "694720b9-d54b-4229-8594-8aa40ef69ed1", false, "ADMIN" },
                    { "user123", 0, "c370cc3d-7bc4-455b-8c55-e24d60ba9eb8", "user@user.user", true, false, null, "USER@USER.USER", "USER", "AQAAAAIAAYagAAAAEBcHnfIcMYJuS5MpuNh6huke/mdVfqrmyOMMkqYMeIr4TFtgjzumzxtvHpVzfr0yxQ==", 10, null, false, "fa09d7ef-b80d-493f-adc3-823bc285b315", false, "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin123", "adminid123" },
                    { "user123", "user123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin123", "adminid123" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user123", "user123" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin123");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user123");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminid123");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123");

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
                    { "757f2ssc-5321-5454-b865-baabba9f48b1", "4c0331ea-76af-4c3c-b985-91165307230a" },
                    { "b2461abb-d772-adb3-caba-89a58cb66c30", "e6e2f41d-9c07-488e-9d0f-ecfa25c3345c" }
                });
        }
    }
}
