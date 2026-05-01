using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindMyCountry.Migrations
{
    /// <inheritdoc />
    public partial class InitCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cId = table.Column<int>(type: "int", nullable: false),
                    countryCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_countryCId",
                        column: x => x.countryCId,
                        principalTable: "Country",
                        principalColumn: "CId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_countryCId",
                table: "City",
                column: "countryCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
