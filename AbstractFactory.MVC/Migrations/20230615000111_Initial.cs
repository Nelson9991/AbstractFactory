using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbstractFactory.MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicicletas",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Gama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicletas", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Gama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Bicicletas");

            migrationBuilder.DropTable(name: "Carros");
        }
    }
}
