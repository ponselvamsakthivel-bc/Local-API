using Microsoft.EntityFrameworkCore.Migrations;

namespace CcsSso.DbMigrations.Migrations
{
    public partial class ChangeRelationshipContactPointContactDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetail_ContactPoint_ContactPointId",
                table: "ContactDetail");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetail_ContactPointId",
                table: "ContactDetail");

            migrationBuilder.DropColumn(
                name: "ContactPointId",
                table: "ContactDetail");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailId",
                table: "ContactPoint",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartyTypeId",
                table: "ContactPoint",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_ContactDetailId",
                table: "ContactPoint",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_PartyTypeId",
                table: "ContactPoint",
                column: "PartyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPoint_ContactDetail_ContactDetailId",
                table: "ContactPoint",
                column: "ContactDetailId",
                principalTable: "ContactDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPoint_PartyType_PartyTypeId",
                table: "ContactPoint",
                column: "PartyTypeId",
                principalTable: "PartyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPoint_ContactDetail_ContactDetailId",
                table: "ContactPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPoint_PartyType_PartyTypeId",
                table: "ContactPoint");

            migrationBuilder.DropIndex(
                name: "IX_ContactPoint_ContactDetailId",
                table: "ContactPoint");

            migrationBuilder.DropIndex(
                name: "IX_ContactPoint_PartyTypeId",
                table: "ContactPoint");

            migrationBuilder.DropColumn(
                name: "ContactDetailId",
                table: "ContactPoint");

            migrationBuilder.DropColumn(
                name: "PartyTypeId",
                table: "ContactPoint");

            migrationBuilder.AddColumn<int>(
                name: "ContactPointId",
                table: "ContactDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetail_ContactPointId",
                table: "ContactDetail",
                column: "ContactPointId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetail_ContactPoint_ContactPointId",
                table: "ContactDetail",
                column: "ContactPointId",
                principalTable: "ContactPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
