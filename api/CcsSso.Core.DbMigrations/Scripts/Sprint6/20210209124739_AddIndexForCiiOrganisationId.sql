-- This includes the index creation for "CiiOrganisationId".
-- Also this includes some changes done by Lee to make the columns nullable on "PhysicalAddress" table

START TRANSACTION;

ALTER TABLE "PhysicalAddress" ALTER COLUMN "StreetAddress" DROP NOT NULL;

ALTER TABLE "PhysicalAddress" ALTER COLUMN "Region" DROP NOT NULL;

ALTER TABLE "PhysicalAddress" ALTER COLUMN "PostalCode" DROP NOT NULL;

ALTER TABLE "PhysicalAddress" ALTER COLUMN "Locality" DROP NOT NULL;

ALTER TABLE "PhysicalAddress" ALTER COLUMN "CountryCode" DROP NOT NULL;

CREATE INDEX "IX_Organisation_CiiOrganisationId" ON "Organisation" ("CiiOrganisationId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210209124739_AddIndexForCiiOrganisationId', '5.0.2');

COMMIT;

