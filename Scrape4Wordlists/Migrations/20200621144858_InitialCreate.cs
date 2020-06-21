using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scrape4Wordlists.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScrapeUri",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbsoluteUri = table.Column<string>(nullable: true),
                    Scheme = table.Column<string>(nullable: true),
                    Host = table.Column<string>(nullable: true),
                    QueryParams = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Scraped = table.Column<bool>(nullable: false),
                    ScrapeFailed = table.Column<bool>(nullable: false),
                    ScrapeAttempts = table.Column<int>(nullable: false),
                    ScrapeDataTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapeUri", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrapeUri");
        }
    }
}
