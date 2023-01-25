using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDos.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Todo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Todo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Todo");
        }
    }
}
