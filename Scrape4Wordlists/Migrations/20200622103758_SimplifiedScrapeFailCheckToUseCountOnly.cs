using Microsoft.EntityFrameworkCore.Migrations;

namespace Scrape4Wordlists.Migrations
{
    public partial class SimplifiedScrapeFailCheckToUseCountOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScrapeFailed",
                table: "ScrapeUri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ScrapeFailed",
                table: "ScrapeUri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
