using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CcsSso.DbMigrations.Migrations
{
    public partial class AddContactPointReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactPointReasonId",
                table: "ContactPoint",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactPointReason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPointReason", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_ContactPointReasonId",
                table: "ContactPoint",
                column: "ContactPointReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPoint_ContactPointReason_ContactPointReasonId",
                table: "ContactPoint",
                column: "ContactPointReasonId",
                principalTable: "ContactPointReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPoint_ContactPointReason_ContactPointReasonId",
                table: "ContactPoint");

            migrationBuilder.DropTable(
                name: "ContactPointReason");

            migrationBuilder.DropIndex(
                name: "IX_ContactPoint_ContactPointReasonId",
                table: "ContactPoint");

            migrationBuilder.DropColumn(
                name: "ContactPointReasonId",
                table: "ContactPoint");
        }
    }
}
