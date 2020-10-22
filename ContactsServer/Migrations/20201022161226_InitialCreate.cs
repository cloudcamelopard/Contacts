using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 32, nullable: false),
                    UseRole = table.Column<string>(maxLength: 32, nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    Hash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Hash", "Salt", "UseRole", "UserName" },
                values: new object[] { 1, "Ronny Andersson", "MaQmTTsyNkDc5jm35Uy5y/lRYbrRo3tdgnH2/6F25mZ3umaMOAancIVyMCMgHlTcfijIGWxyYXSC7r7KjClNCIV2U0dQ3nDYxKxIhiXvtmyuciU8kODJzyg7msqE9OFCBYzSNrPhzrMl7tKpgV4Y3w7qgSpwHwnydaiKIEr0BrIuCOuqn35KzEcnK8iW89Ne5Ir9whnxFdHQbfIt7yU4+zqREq8M3Nc8CrkGg0KwMPMZ3r0Sm9E5VvRcRNVHqRQIlcPZivMyupK5Li1Uq9lQqIG+3HeGo1vf6oNiKJ+Qe/EzMEU9gPjCguDP6vuucS6GUg/4HM/EmgEoZDkauuL+lA==", "Iy1rku0NDw+fuprai0A6MWHcS5Xhi7OJDeHu7JptRyHNxHEmfIY+QQ/zV/oqMAFRkvZFVEyyrS9Bn+r1mcGomQ==", "Admin", "roan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
