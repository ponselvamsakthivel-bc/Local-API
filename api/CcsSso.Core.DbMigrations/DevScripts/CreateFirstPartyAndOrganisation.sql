-- To create first pary and organisation.

INSERT INTO public."Party"(
	"PartyTypeId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES (1, 0, 0, now(), now(), false);

INSERT INTO public."Organisation"(
	"OrganisationUri", "RightToBuy", "PartyId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('testorg.com', true, 1, 0, 0, now(), now(), false);
