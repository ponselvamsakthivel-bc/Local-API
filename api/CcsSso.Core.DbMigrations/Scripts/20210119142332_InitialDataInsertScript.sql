-- Insert Initial party type and virtual address type data

INSERT INTO public."PartyType"("PartyTypeName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('INTERNAL_ORGANISATION', 0, 0, now(), now(), false);

INSERT INTO public."PartyType"("PartyTypeName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('EXTERNAL_ORGANISATION', 0, 0, now(), now(), false);

INSERT INTO public."PartyType"("PartyTypeName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('USER', 0, 0, now(), now(), false);

INSERT INTO public."PartyType"("PartyTypeName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('NON_USER', 0, 0, now(), now(), false);


INSERT INTO public."VirtualAddressType"("Name", "Description", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('EMAIL','Email', 0, 0, now(), now(), false);

INSERT INTO public."VirtualAddressType"("Name", "Description", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('WEB_ADDRESS','Web Address', 0, 0, now(), now(), false);

INSERT INTO public."VirtualAddressType"("Name", "Description", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('PHONE','Phone', 0, 0, now(), now(), false);

INSERT INTO public."VirtualAddressType"("Name", "Description", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted")
	VALUES ('FAX','Fax', 0, 0, now(), now(), false);

