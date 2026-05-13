using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuuxi.SurePath.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "surepath",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TranslationKeys",
                schema: "surepath",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationKeys", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                schema: "surepath",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalSchema: "surepath",
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_TranslationKeys_Key",
                        column: x => x.Key,
                        principalSchema: "surepath",
                        principalTable: "TranslationKeys",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageCode_Key",
                schema: "surepath",
                table: "Translations",
                columns: new[] { "LanguageCode", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translations_Key",
                schema: "surepath",
                table: "Translations",
                column: "Key");

            migrationBuilder.InsertData(
                schema: "surepath",
                table: "Languages",
                columns: new[] { "Code", "Name", "IsActive" },
                values: new object[,]
                {
                    { "da", "Dansk",   true },
                    { "en", "English", true },
                    { "de", "Deutsch", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Translations",   schema: "surepath");
            migrationBuilder.DropTable(name: "TranslationKeys", schema: "surepath");
            migrationBuilder.DropTable(name: "Languages",      schema: "surepath");
        }
    }
}
