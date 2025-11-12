using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomAuthTestWithDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccountPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserAccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserPolicy = table.Column<string>(type: "TEXT", nullable: true),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserAccountPolicies",
                columns: new[] { "Id", "IsEnabled", "UserAccountId", "UserPolicy" },
                values: new object[,]
                {
                    { 1, true, 1, "VIEW_WEATHER" },
                    { 2, false, 1, "VIEW_COUNTER" },
                    { 3, false, 2, "VIEW_WEATHER" },
                    { 4, true, 2, "VIEW_COUNTER" },
                    { 5, true, 3, "VIEW_WEATHER" },
                    { 6, true, 3, "VIEW_COUNTER" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "weather", "weather" },
                    { 2, "counter", "counter" },
                    { 3, "god", "god" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccountPolicies");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
