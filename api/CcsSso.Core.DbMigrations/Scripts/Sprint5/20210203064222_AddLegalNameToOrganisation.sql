START TRANSACTION;

ALTER TABLE "Organisation" ADD "LegalName" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210203064222_AddLegalNameToOrganisation', '5.0.2');

COMMIT;

