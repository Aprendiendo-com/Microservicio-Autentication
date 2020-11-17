using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Autentication.AccessData.Migrations
{
    public partial class dobleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UsuarioRoles",
                columns: new[] { "UsuarioRolId", "RolId", "UsuarioId" },
                values: new object[,]
                {
                    { 20, 1, 20 },
                    { 21, 1, 21 },
                    { 22, 1, 22 },
                    { 23, 1, 23 },
                    { 24, 1, 24 },
                    { 25, 1, 25 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumn: "UsuarioRolId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumn: "UsuarioRolId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumn: "UsuarioRolId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumn: "UsuarioRolId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumn: "UsuarioRolId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumn: "UsuarioRolId",
                keyValue: 25);
        }
    }
}
