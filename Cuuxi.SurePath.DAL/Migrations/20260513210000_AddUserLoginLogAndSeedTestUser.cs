using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuuxi.SurePath.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLoginLogAndSeedTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoginLogs",
                schema: "surepath",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    LoggedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "surepath",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_UserId",
                schema: "surepath",
                table: "UserLoginLogs",
                column: "UserId");

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [surepath].[Users] ON;
                INSERT INTO [surepath].[Users] ([Id], [FirstName], [LastName], [IsActive], [CountryCode])
                VALUES (1, 'Test', 'Test', 1, 'DK');
                SET IDENTITY_INSERT [surepath].[Users] OFF;
            ");

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [surepath].[UserLogins] ON;
                INSERT INTO [surepath].[UserLogins] ([Id], [UserId], [Provider], [ProviderKey], [ProviderSecret])
                VALUES (1, 1, 'Basic', 'test', '$2a$11$OJ4mDCE1IJDZwkH3rs/R6ur3EyD1x4Gc/uxxWq0mrUunQoDhYsJVK');
                SET IDENTITY_INSERT [surepath].[UserLogins] OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [surepath].[UserLogins] WHERE [Id] = 1;");
            migrationBuilder.Sql("DELETE FROM [surepath].[Users] WHERE [Id] = 1;");

            migrationBuilder.DropTable(
                name: "UserLoginLogs",
                schema: "surepath");
        }
    }
}
