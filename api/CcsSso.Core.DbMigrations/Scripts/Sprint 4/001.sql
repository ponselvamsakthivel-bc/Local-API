START TRANSACTION;

ALTER TABLE "User" ADD "UserName" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210122063022_UserNameColumntouser', '5.0.2');

COMMIT;

