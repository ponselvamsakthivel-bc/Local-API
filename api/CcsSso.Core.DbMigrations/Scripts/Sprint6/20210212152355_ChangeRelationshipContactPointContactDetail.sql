START TRANSACTION;

ALTER TABLE "ContactDetail" DROP CONSTRAINT "FK_ContactDetail_ContactPoint_ContactPointId";

DROP INDEX "IX_ContactDetail_ContactPointId";

ALTER TABLE "ContactDetail" DROP COLUMN "ContactPointId";

ALTER TABLE "ContactPoint" ADD "ContactDetailId" integer NOT NULL DEFAULT 0;

ALTER TABLE "ContactPoint" ADD "PartyTypeId" integer NOT NULL DEFAULT 0;

CREATE INDEX "IX_ContactPoint_ContactDetailId" ON "ContactPoint" ("ContactDetailId");

CREATE INDEX "IX_ContactPoint_PartyTypeId" ON "ContactPoint" ("PartyTypeId");

ALTER TABLE "ContactPoint" ADD CONSTRAINT "FK_ContactPoint_ContactDetail_ContactDetailId" FOREIGN KEY ("ContactDetailId") REFERENCES "ContactDetail" ("Id") ON DELETE CASCADE;

ALTER TABLE "ContactPoint" ADD CONSTRAINT "FK_ContactPoint_PartyType_PartyTypeId" FOREIGN KEY ("PartyTypeId") REFERENCES "PartyType" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210212152355_ChangeRelationshipContactPointContactDetail', '5.0.2');

COMMIT;

