using Microsoft.EntityFrameworkCore.Migrations;

namespace CcsSso.DbMigrations.Migrations
{
    public partial class DBIdentityColumnChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_IdentityProvider_IdentityProviderIdpId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdentityProviderIdpId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdentityProviderIdpId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "VirtualAddressTypeId",
                table: "VirtualAddressType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VirtualAddressId",
                table: "VirtualAddress",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserSettingTypeId",
                table: "UserSettingType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserSettingId",
                table: "UserSetting",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserGroupMembershipId",
                table: "UserGroupMembership",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "UserGroup",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserAccessRoleId",
                table: "UserAccessRole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdpId",
                table: "User",
                newName: "IdentityProviderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TradingOrganisationId",
                table: "TradingOrganisation",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProcurementGroupId",
                table: "ProcurementGroup",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PhysicalAddressId",
                table: "PhysicalAddress",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PartyTypeId",
                table: "PartyType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PartyId",
                table: "Party",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrganisationEnterpriseTypeId",
                table: "OrganisationEnterpriseType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrganisationAccessRoleId",
                table: "OrganisationAccessRole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrganisationId",
                table: "Organisation",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdpId",
                table: "IdentityProvider",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EnterpriseTypeId",
                table: "EnterpriseType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactPointId",
                table: "ContactPoint",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactDetailId",
                table: "ContactDetail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CcsAccessRoleId",
                table: "CcsAccessRole",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CiiOrganisationId",
                table: "Organisation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityProviderId",
                table: "User",
                column: "IdentityProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_IdentityProvider_IdentityProviderId",
                table: "User",
                column: "IdentityProviderId",
                principalTable: "IdentityProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_IdentityProvider_IdentityProviderId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdentityProviderId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CiiOrganisationId",
                table: "Organisation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VirtualAddressType",
                newName: "VirtualAddressTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VirtualAddress",
                newName: "VirtualAddressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserSettingType",
                newName: "UserSettingTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserSetting",
                newName: "UserSettingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserGroupMembership",
                newName: "UserGroupMembershipId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserGroup",
                newName: "UserGroupId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAccessRole",
                newName: "UserAccessRoleId");

            migrationBuilder.RenameColumn(
                name: "IdentityProviderId",
                table: "User",
                newName: "IdpId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TradingOrganisation",
                newName: "TradingOrganisationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProcurementGroup",
                newName: "ProcurementGroupId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PhysicalAddress",
                newName: "PhysicalAddressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PartyType",
                newName: "PartyTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Party",
                newName: "PartyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrganisationEnterpriseType",
                newName: "OrganisationEnterpriseTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrganisationAccessRole",
                newName: "OrganisationAccessRoleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Organisation",
                newName: "OrganisationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IdentityProvider",
                newName: "IdpId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EnterpriseType",
                newName: "EnterpriseTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContactPoint",
                newName: "ContactPointId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContactDetail",
                newName: "ContactDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CcsAccessRole",
                newName: "CcsAccessRoleId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentityProviderIdpId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityProviderIdpId",
                table: "User",
                column: "IdentityProviderIdpId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_IdentityProvider_IdentityProviderIdpId",
                table: "User",
                column: "IdentityProviderIdpId",
                principalTable: "IdentityProvider",
                principalColumn: "IdpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
