using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideBooking.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_BookingRequests_bookingRequestId",
                table: "Rides");

            migrationBuilder.AlterColumn<int>(
                name: "bookingRequestId",
                table: "Rides",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_BookingRequests_bookingRequestId",
                table: "Rides",
                column: "bookingRequestId",
                principalTable: "BookingRequests",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_BookingRequests_bookingRequestId",
                table: "Rides");

            migrationBuilder.AlterColumn<int>(
                name: "bookingRequestId",
                table: "Rides",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_BookingRequests_bookingRequestId",
                table: "Rides",
                column: "bookingRequestId",
                principalTable: "BookingRequests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
