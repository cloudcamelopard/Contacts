using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsServer.Migrations
{
    public partial class SeedingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Hash", "Salt" },
                values: new object[] { "Ronnie Andersson", "qonlR9IP8VmtOUeXzaCqluC9qlGLY8/6MilE8ZS8/lyXZHpfN9crO/lgafRR0x2GWcVDL5sA1qmm5Xry5XFJNaoizqVz9m0Oze4cJg9FrqIB7Xi8Lp95O+hIfaa1dp+IOh5VPhAbJjvK32iAHSbUDy0Mscwq7Z92vog738INa4OLzR2VIgFsBAINoO98fT6swZfG0XolbaFUSel1XxhjxqaUAb7/uScF/RuAKQwSpxEtJz06guzz6qfeK0K2QS7Ohig9wnZ1eD/UKQGfAg5oU4Myp2r2t0jnNNQk9HqZSDWJ1kuTM6TIML8FzC6x3D6J+rIowkXJQ+uP6fGHgc0/3w==", "nEgXnlZ8w0NZVLmqcTZ4kBE3P0Ec6Ub1Yn3k8/9gvXNvB19zOfYaOjfCUX0mSiXEIma/7pgMereY2KTXoMKbug==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Hash", "Salt" },
                values: new object[] { "Ronny Andersson", "MaQmTTsyNkDc5jm35Uy5y/lRYbrRo3tdgnH2/6F25mZ3umaMOAancIVyMCMgHlTcfijIGWxyYXSC7r7KjClNCIV2U0dQ3nDYxKxIhiXvtmyuciU8kODJzyg7msqE9OFCBYzSNrPhzrMl7tKpgV4Y3w7qgSpwHwnydaiKIEr0BrIuCOuqn35KzEcnK8iW89Ne5Ir9whnxFdHQbfIt7yU4+zqREq8M3Nc8CrkGg0KwMPMZ3r0Sm9E5VvRcRNVHqRQIlcPZivMyupK5Li1Uq9lQqIG+3HeGo1vf6oNiKJ+Qe/EzMEU9gPjCguDP6vuucS6GUg/4HM/EmgEoZDkauuL+lA==", "Iy1rku0NDw+fuprai0A6MWHcS5Xhi7OJDeHu7JptRyHNxHEmfIY+QQ/zV/oqMAFRkvZFVEyyrS9Bn+r1mcGomQ==" });
        }
    }
}
