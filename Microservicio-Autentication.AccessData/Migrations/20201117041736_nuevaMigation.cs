using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservicio_Autentication.AccessData.Migrations
{
    public partial class nuevaMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellido", "Contraseña", "Email", "Nombre" },
                values: new object[,]
                {
                    { 20, "Olivera", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "lolivera.unaj@gmail.com", "Lucas" },
                    { 21, "Conde", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "sergiounaj@gmail.com", "Sergio" },
                    { 22, "Jorge", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "octaviojorge37@gmail.com", "Octavio" },
                    { 23, "Amet", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "leonardoAmet@gmail.com", "Leonardo" },
                    { 24, "Osio", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "jorgeosio@gmail.com", "Jorge" },
                    { 25, "Rosa", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "mariarosa@gmail.com", "Maria" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 25);
        }
    }
}
