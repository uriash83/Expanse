using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expanse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "CryptoCurrencies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "CryptoCurrencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
