using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DFDSTruckPlan.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPSPositions_GPSDevices_GPSDeviceId",
                table: "GPSPositions");

            migrationBuilder.AlterColumn<int>(
                name: "GPSDeviceId",
                table: "GPSPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Birthdate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1970, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe" },
                    { 2, new DateTime(1985, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "GPSDevices",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "GPSPositions",
                columns: new[] { "Id", "GPSDeviceId", "Latitude", "Longitude", "TimeStamp" },
                values: new object[,]
                {
                    { 1, 1, 52.520000000000003, 13.404999999999999, new DateTime(2024, 9, 30, 22, 25, 40, 123, DateTimeKind.Local).AddTicks(9056) },
                    { 2, 1, 48.8566, 2.3521999999999998, new DateTime(2024, 9, 30, 22, 25, 40, 123, DateTimeKind.Local).AddTicks(9119) },
                    { 3, 2, 51.507399999999997, -0.1278, new DateTime(2024, 9, 30, 22, 25, 40, 123, DateTimeKind.Local).AddTicks(9124) }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "GPSDeviceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "TruckPlans",
                columns: new[] { "Id", "DriverId", "EndTime", "StartTime", "TruckId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 30, 22, 25, 40, 123, DateTimeKind.Local).AddTicks(9174), new DateTime(2024, 9, 30, 17, 25, 40, 123, DateTimeKind.Local).AddTicks(9167), 1 },
                    { 2, 2, new DateTime(2024, 9, 30, 22, 25, 40, 123, DateTimeKind.Local).AddTicks(9181), new DateTime(2024, 9, 30, 16, 25, 40, 123, DateTimeKind.Local).AddTicks(9178), 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GPSPositions_GPSDevices_GPSDeviceId",
                table: "GPSPositions",
                column: "GPSDeviceId",
                principalTable: "GPSDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPSPositions_GPSDevices_GPSDeviceId",
                table: "GPSPositions");

            migrationBuilder.DeleteData(
                table: "GPSPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GPSPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GPSPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TruckPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TruckPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GPSDevices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GPSDevices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "GPSDeviceId",
                table: "GPSPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GPSPositions_GPSDevices_GPSDeviceId",
                table: "GPSPositions",
                column: "GPSDeviceId",
                principalTable: "GPSDevices",
                principalColumn: "Id");
        }
    }
}
