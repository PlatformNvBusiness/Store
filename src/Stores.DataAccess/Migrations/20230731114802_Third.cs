using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stores.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Stores",
                newName: "AddressLineFirst");

            migrationBuilder.AddColumn<string>(
                name: "AddreesLineSecond",
                table: "Stores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Stores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddreesLineSecond",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "AddressLineFirst",
                table: "Stores",
                newName: "Address");
        }
    }
}
