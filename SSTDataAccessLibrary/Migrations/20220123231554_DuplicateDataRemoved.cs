using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSTDataAccessLibrary.Migrations
{
    public partial class DuplicateDataRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62ecf49c-821e-42c8-8d18-903fa2df01e5", "8c5a289f-d439-4247-b0c7-2dd987ae5f87", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93cfc212-21ec-41c7-8d77-a4e78eee82ee", "52bc4726-e9cc-4f1f-b974-1ec2f7fa75bd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "79adb8ac-a602-43ff-b374-dac054262929", 0, "e766da3e-caea-4107-8cba-fdda98b02852", "Typer", "newuser@newuser.com", false, false, null, "aaaa", null, null, null, null, false, "67b6ddb1-5577-4dfd-abb7-7a5137351678", false, "OLDOLD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62ecf49c-821e-42c8-8d18-903fa2df01e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93cfc212-21ec-41c7-8d77-a4e78eee82ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79adb8ac-a602-43ff-b374-dac054262929");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

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
    }
}
