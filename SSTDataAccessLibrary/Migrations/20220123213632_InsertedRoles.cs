using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSTDataAccessLibrary.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eaefdd55-2c37-4ce0-a910-b696835d2100");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76ac0cfd-dbe0-4f9d-b202-7c486813cfd9", "f62a628c-5377-4d32-bd1d-09051ea29a41", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0cb73f6-db05-4686-a3f3-5386a2ebfed7", "739bbfe1-0000-4c6a-b7ab-8ea817622eea", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "76deb241-8e3d-45d1-a467-445a9555292f", 0, "ceb0a897-e1ce-441c-80f4-648353495720", "Typer", null, false, false, null, "New User", null, null, "newuser", null, null, false, "b31280ae-58eb-457b-990d-c5182e2510f6", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76ac0cfd-dbe0-4f9d-b202-7c486813cfd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0cb73f6-db05-4686-a3f3-5386a2ebfed7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76deb241-8e3d-45d1-a467-445a9555292f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eaefdd55-2c37-4ce0-a910-b696835d2100", 0, "307d6aed-6a31-457e-b508-be70ac65a209", "Typer", null, false, false, null, "New User", null, null, "newuser", null, null, false, "78505112-4c0a-4844-93f3-f7b770eb1827", false, null });
        }
    }
}
