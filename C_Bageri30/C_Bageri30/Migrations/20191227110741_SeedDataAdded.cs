using Microsoft.EntityFrameworkCore.Migrations;

namespace C_Bager30.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "DbContact",
            columns: new[] { "Id", "Name", "WebbPage", "StreetAdress",
                            "CityAdress", "Mail", "Phone"},
            values: new object[,]
            {
                {
                1,
                "Baka på nätet",
                "www.bakeonnet.se",
                "Bakagatan 1",
                "755 90 Nätstaden",
                "bakeonnet@gmail.com",
                "012-34 56 789"
                }
            });

            migrationBuilder.InsertData(
            table: "DbProduct",
            columns: new[] { "Id", "Name", "Besk", "Price" },
            values: new object[,]
            {
                { 1, "Kardemummabulle", "beskrivning", 20 },
                { 2, "Princesstårta", "beskrivning", 100 },
                { 3, "Kladdkaka", "beskrivning", 15 },
                { 4, "Mazarin", "beskrivning", 10 },
                { 5, "Skorpa", "beskrivning", 5 }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbContact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DbProduct",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DbProduct",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DbProduct",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DbProduct",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DbProduct",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
