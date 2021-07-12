using Microsoft.EntityFrameworkCore.Migrations;

namespace INDIMIN.Migrations
{
    public partial class IdRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idRol",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idRol",
                table: "Usuarios");
        }
    }
}
