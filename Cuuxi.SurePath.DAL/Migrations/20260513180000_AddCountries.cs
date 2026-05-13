using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuuxi.SurePath.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "surepath",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.InsertData(
                schema: "surepath",
                table: "Countries",
                columns: new[] { "Code", "Name", "LanguageCode" },
                values: new object[,]
                {
                    { "DK", "Danmark", "da" },
                    { "NO", "Norge", "no" },
                    { "SE", "Sverige", "sv" },
                    { "DE", "Tyskland", "de" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries",
                schema: "surepath");
        }
    }
}
