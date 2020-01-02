using Microsoft.EntityFrameworkCore.Migrations;

namespace C_Bageri30.Migrations
{
    public partial class DataCommentaryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "DbCommentary",
            columns: new[] { "Id", "ProductId", "Text" },
            values: new object[,]
            {
                { "1", 1, "kommentar 1" },
                { "2", 2, "kommentar 2" },
                { "3", 1, "kommentar 3" }
            });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbCommentary",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "DbCommentary",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "DbCommentary",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
