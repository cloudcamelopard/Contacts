using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsServer.Migrations
{
    public partial class ContactTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "zQPpWEC0z2ril1CmrPPj7uUd3BjlpaBA/pFQKkOhnCTiD/LPlXISHnHVjUR/RmZAsBNqNrUmBGUF/5X0ifQFPTTLGAZWas+guw/va09PORohIgO0Yt6aM7zuhicP6TnoiHA51N18wZxM41HKgl/wJlHKkKX16kS9jVvlMnkBk1Q+VWFS37la6xPdqArUDBeFj3A2pufOiTO7fagYnYpBhMyRGTM/FbreCwOrXPVtLHAhMMlfItzSdBO0Kqe1Ri6xPfvsSvxX0E9ooDMWHyjgJR5DOPtREfzTMqZBjlLlHPST7GjFfSfm0HYcrLs6psYEafL7rQYkEo8YKpBGn0IizA==", "KiPSGT4b3gTS542WArx7cgepvAqTS4mtLJXyvniULdOy2qpkYmQKCzgoLdRad5axmxaihHdgKXH14pbQ5IHShA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "qonlR9IP8VmtOUeXzaCqluC9qlGLY8/6MilE8ZS8/lyXZHpfN9crO/lgafRR0x2GWcVDL5sA1qmm5Xry5XFJNaoizqVz9m0Oze4cJg9FrqIB7Xi8Lp95O+hIfaa1dp+IOh5VPhAbJjvK32iAHSbUDy0Mscwq7Z92vog738INa4OLzR2VIgFsBAINoO98fT6swZfG0XolbaFUSel1XxhjxqaUAb7/uScF/RuAKQwSpxEtJz06guzz6qfeK0K2QS7Ohig9wnZ1eD/UKQGfAg5oU4Myp2r2t0jnNNQk9HqZSDWJ1kuTM6TIML8FzC6x3D6J+rIowkXJQ+uP6fGHgc0/3w==", "nEgXnlZ8w0NZVLmqcTZ4kBE3P0Ec6Ub1Yn3k8/9gvXNvB19zOfYaOjfCUX0mSiXEIma/7pgMereY2KTXoMKbug==" });
        }
    }
}
