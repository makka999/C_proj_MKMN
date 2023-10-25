using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace C_proj_MKMN.Data.Migrations
{
    /// <inheritdoc />
    public partial class role5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757f21f5-5d21-4f74-b845-ba76eb9f48b1", "06a551f1-43f6-4e91-8ab1-f16e50928059" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2461798-d662-4cc3-92db-89251db66c30", "6bb509ed-330c-4e56-bf4c-dcc057a9c871" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757f21f5-5d21-4f74-b845-ba76eb9f48b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2461798-d662-4cc3-92db-89251db66c30");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06a551f1-43f6-4e91-8ab1-f16e50928059");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bb509ed-330c-4e56-bf4c-dcc057a9c871");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin123role", "1", "Admin", "ADMIN" },
                    { "user123role", "2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "user123role", "67f34799-a67a-40ef-afa0-7d1fc9965c21" },
                    { "admin123role", "eaccdc25-300a-4012-a799-c844ae6e9902" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user123role", "67f34799-a67a-40ef-afa0-7d1fc9965c21" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin123role", "eaccdc25-300a-4012-a799-c844ae6e9902" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin123role");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user123role");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "757f21f5-5d21-4f74-b845-ba76eb9f48b1", "2", "User", "USER" },
                    { "b2461798-d662-4cc3-92db-89251db66c30", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordIndividualLength", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06a551f1-43f6-4e91-8ab1-f16e50928059", 0, "aaa44e09-23c6-41e1-a14a-c48a84b3dfd7", "user@user.user", true, false, null, "USER@USER.USER", "USER", "AQAAAAIAAYagAAAAEEflUIAVpWqJULjG6m0wrRS5T1v6gIwbuuvFhgEv8oL3pQH6z9U0UPPo3p8p253cxg==", 10, null, false, "116e2e6f-4385-42c4-96ef-2a3cf3999d91", false, "USER" },
                    { "6bb509ed-330c-4e56-bf4c-dcc057a9c871", 0, "8b2375ce-bade-46fb-a5f2-4faeba07f559", "admin@admin.admin", true, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", "AQAAAAIAAYagAAAAENqEPawfgGTm/7yD6vaIE3xk5ufrkXJFzgG5JChS4jUOENj7sX71swpn9zAf5bkd0g==", 10, null, false, "e9d1c166-d7ae-42b1-96a8-6b0d8ae7ed89", false, "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "757f21f5-5d21-4f74-b845-ba76eb9f48b1", "06a551f1-43f6-4e91-8ab1-f16e50928059" },
                    { "b2461798-d662-4cc3-92db-89251db66c30", "6bb509ed-330c-4e56-bf4c-dcc057a9c871" }
                });
        }
    }
}
