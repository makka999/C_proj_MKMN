using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace C_proj_MKMN.Data.Migrations
{
    /// <inheritdoc />
    public partial class role6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user123role", "67f34799-a67a-40ef-afa0-7d1fc9965c21" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin123role", "eaccdc25-300a-4012-a799-c844ae6e9902" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "user123role", "67f34799-a67a-40ef-afa0-7d1fc9965c21" },
                    { "admin123role", "eaccdc25-300a-4012-a799-c844ae6e9902" }
                });
        }
    }
}
