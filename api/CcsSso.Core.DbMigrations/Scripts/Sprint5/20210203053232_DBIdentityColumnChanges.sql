START TRANSACTION;

ALTER TABLE "User" DROP CONSTRAINT "FK_User_IdentityProvider_IdentityProviderIdpId";

DROP INDEX "IX_User_IdentityProviderIdpId";

ALTER TABLE "User" DROP COLUMN "FirstName";

ALTER TABLE "User" DROP COLUMN "IdentityProviderIdpId";

ALTER TABLE "User" DROP COLUMN "SurName";

ALTER TABLE "VirtualAddressType" RENAME COLUMN "VirtualAddressTypeId" TO "Id";

ALTER TABLE "VirtualAddress" RENAME COLUMN "VirtualAddressId" TO "Id";

ALTER TABLE "UserSettingType" RENAME COLUMN "UserSettingTypeId" TO "Id";

ALTER TABLE "UserSetting" RENAME COLUMN "UserSettingId" TO "Id";

ALTER TABLE "UserGroupMembership" RENAME COLUMN "UserGroupMembershipId" TO "Id";

ALTER TABLE "UserGroup" RENAME COLUMN "UserGroupId" TO "Id";

ALTER TABLE "UserAccessRole" RENAME COLUMN "UserAccessRoleId" TO "Id";

ALTER TABLE "User" RENAME COLUMN "IdpId" TO "IdentityProviderId";

ALTER TABLE "User" RENAME COLUMN "UserId" TO "Id";

ALTER TABLE "TradingOrganisation" RENAME COLUMN "TradingOrganisationId" TO "Id";

ALTER TABLE "ProcurementGroup" RENAME COLUMN "ProcurementGroupId" TO "Id";

ALTER TABLE "PhysicalAddress" RENAME COLUMN "PhysicalAddressId" TO "Id";

ALTER TABLE "Person" RENAME COLUMN "PersonId" TO "Id";

ALTER TABLE "PartyType" RENAME COLUMN "PartyTypeId" TO "Id";

ALTER TABLE "Party" RENAME COLUMN "PartyId" TO "Id";

ALTER TABLE "OrganisationEnterpriseType" RENAME COLUMN "OrganisationEnterpriseTypeId" TO "Id";

ALTER TABLE "OrganisationAccessRole" RENAME COLUMN "OrganisationAccessRoleId" TO "Id";

ALTER TABLE "Organisation" RENAME COLUMN "OrganisationId" TO "Id";

ALTER TABLE "IdentityProvider" RENAME COLUMN "IdpId" TO "Id";

ALTER TABLE "EnterpriseType" RENAME COLUMN "EnterpriseTypeId" TO "Id";

ALTER TABLE "ContactPoint" RENAME COLUMN "ContactPointId" TO "Id";

ALTER TABLE "ContactDetail" RENAME COLUMN "ContactDetailId" TO "Id";

ALTER TABLE "CcsAccessRole" RENAME COLUMN "CcsAccessRoleId" TO "Id";

ALTER TABLE "Organisation" ADD "CiiOrganisationId" text NULL;

CREATE INDEX "IX_User_IdentityProviderId" ON "User" ("IdentityProviderId");

ALTER TABLE "User" ADD CONSTRAINT "FK_User_IdentityProvider_IdentityProviderId" FOREIGN KEY ("IdentityProviderId") REFERENCES "IdentityProvider" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210203053232_DBIdentityColumnChanges', '5.0.2');

COMMIT;

