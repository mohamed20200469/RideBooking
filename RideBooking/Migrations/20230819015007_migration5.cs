using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideBooking.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Rides",
                newName: "dateTimeStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTimeEnd",
                table: "Rides",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dropoffLocation",
                table: "Rides",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ended",
                table: "Rides",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTimeEnd",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "dropoffLocation",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "ended",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "dateTimeStart",
                table: "Rides",
                newName: "dateTime");
        }
    }
}
