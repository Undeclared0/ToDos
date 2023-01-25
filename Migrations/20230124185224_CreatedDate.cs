using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDos.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Todo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
