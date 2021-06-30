using Microsoft.EntityFrameworkCore.Migrations;

namespace ParsingAndDropping.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Droppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAZWAPRODUKTU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GTIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KLASYFIKACJAGPC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POBIERZ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Droppings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Droppings");
        }
    }
}
