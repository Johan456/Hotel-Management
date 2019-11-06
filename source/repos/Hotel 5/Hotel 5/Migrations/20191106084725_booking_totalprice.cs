using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_5.Migrations
{
    public partial class booking_totalprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0513644b-d0fe-4f4c-a04f-9038cec2693c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b364e5b4-b114-4ed1-9e05-3909caa58494");

            migrationBuilder.AddColumn<int>(
                name: "RoomType",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ReservationPrice",
                table: "Bookings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Amenities",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa5de617-aa94-4cd9-b740-cac7876943fd", "34d18b2b-b531-44a4-aa71-a57b925241ac", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e509000-46b8-4d21-a34d-2e2586697139", "a5c2a832-ce42-4a9d-b93a-afc4e0f58954", "Receptionist", "RECEPTIONIST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e509000-46b8-4d21-a34d-2e2586697139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5de617-aa94-4cd9-b740-cac7876943fd");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReservationPrice",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Amenities");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0513644b-d0fe-4f4c-a04f-9038cec2693c", "55f3eef5-1f84-461d-8224-72d531a599fb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b364e5b4-b114-4ed1-9e05-3909caa58494", "02d3ef45-2482-46d6-a241-6967c1988b6a", "Receptionist", "RECEPTIONIST" });
        }
    }
}
