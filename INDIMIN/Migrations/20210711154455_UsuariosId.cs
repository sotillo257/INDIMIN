using Microsoft.EntityFrameworkCore.Migrations;

namespace INDIMIN.Migrations
{
    public partial class UsuariosId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAxie_Usuarios_UsuariosId",
                table: "CuentaAxie");

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosId",
                table: "CuentaAxie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAxie_Usuarios_UsuariosId",
                table: "CuentaAxie",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAxie_Usuarios_UsuariosId",
                table: "CuentaAxie");

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosId",
                table: "CuentaAxie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAxie_Usuarios_UsuariosId",
                table: "CuentaAxie",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
