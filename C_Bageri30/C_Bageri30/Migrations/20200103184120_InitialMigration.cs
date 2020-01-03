using Microsoft.EntityFrameworkCore.Migrations;

namespace C_Bageri30.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbCommentary",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCommentary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    WebbPage = table.Column<string>(nullable: true),
                    StreetAdress = table.Column<string>(nullable: true),
                    CityAdress = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbGrades",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Besk = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProduct", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbCommentary");

            migrationBuilder.DropTable(
                name: "DbContact");

            migrationBuilder.DropTable(
                name: "DbGrades");

            migrationBuilder.DropTable(
                name: "DbProduct");
        }
    }
}
