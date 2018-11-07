using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITS.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datos_personales",
                columns: table => new
                {
                    Id_datos = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    A_paterno = table.Column<string>(maxLength: 50, nullable: false),
                    A_materno = table.Column<string>(maxLength: 50, nullable: false),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos_personales", x => x.Id_datos);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_usuario",
                columns: table => new
                {
                    id_tipo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_tipo_usuario = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_usuario", x => x.id_tipo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datos_personales");

            migrationBuilder.DropTable(
                name: "Tipo_usuario");
        }
    }
}
