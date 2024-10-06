using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Devices_PropValues_Seaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "~/assets/img/Laptops.png");

            migrationBuilder.InsertData(
                table: "devices",
                columns: new[] { "Id", "Acquisition_Date", "Category_Id", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zbook G3" },
                    { 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "MacBook Pro" },
                    { 3, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dell XPS 13" },
                    { 4, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HP LaserJet" },
                    { 5, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Epson EcoTank" },
                    { 6, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Canon Pixma" },
                    { 7, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Cisco Catalyst 9200" },
                    { 8, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Netgear ProSAFE" },
                    { 9, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "TP-Link TL-SG108" }
                });

            migrationBuilder.InsertData(
                table: "devicePropertyValues",
                columns: new[] { "Device_Id", "Property_Id", "Property_Value" },
                values: new object[,]
                {
                    { 1, 1, "Core i7 8551Hq" },
                    { 1, 2, "16GB" },
                    { 1, 3, "512GB SSD" },
                    { 2, 1, "M1 Pro" },
                    { 2, 2, "32GB" },
                    { 2, 3, "1TB SSD" },
                    { 3, 1, "Core i5 1135G7" },
                    { 3, 2, "8GB" },
                    { 3, 3, "256GB SSD" },
                    { 4, 4, "20ppm" },
                    { 4, 5, "1200x1200 dpi" },
                    { 4, 6, "A4" },
                    { 5, 4, "15ppm" },
                    { 5, 5, "1440x720 dpi" },
                    { 5, 6, "A3" },
                    { 6, 4, "25ppm" },
                    { 6, 5, "4800x2400 dpi" },
                    { 6, 6, "Letter" },
                    { 7, 7, "48 Ports" },
                    { 7, 8, "1Gbps" },
                    { 7, 9, "Yes" },
                    { 8, 7, "24 Ports" },
                    { 8, 8, "1Gbps" },
                    { 8, 9, "Yes" },
                    { 9, 7, "8 Ports" },
                    { 9, 8, "1Gbps" },
                    { 9, 9, "No" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "devicePropertyValues",
                keyColumns: new[] { "Device_Id", "Property_Id" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "~/assets/img/Laptops.png}");
        }
    }
}
