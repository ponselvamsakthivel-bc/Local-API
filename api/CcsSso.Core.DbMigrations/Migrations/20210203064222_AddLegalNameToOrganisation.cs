using Microsoft.EntityFrameworkCore.Migrations;

namespace CcsSso.DbMigrations.Migrations
{
    public partial class AddLegalNameToOrganisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "Organisation",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "Organisation");
        }
    }
}
