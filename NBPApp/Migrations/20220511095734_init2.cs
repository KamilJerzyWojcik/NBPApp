using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBPApp.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TradingDate",
                table: "Currency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TradingDate",
                table: "Currency",
                type: "datetime2",
                nullable: true);
        }
    }
}
