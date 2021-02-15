namespace CcsSso.Domain.Constants
{
  public static class Contstant
  {
    public const string InvalidContactType = "INVALID_CONTACT_TYPE";
    public const string DAApiRequestContentType = "application/json";
  }

  public static class ErrorConstant
  {
    public const string EntityNotFound = "ERROR_ENTITY_NOT_FOUND";
    public const string ErrorInvalidContacts = "INVALID_CONTACTS";
    public const string ErrorInvalidContactReason = "INVALID_CONTACT_REASON";
    public const string ErrorInvalidContactName = "INVALID_CONTACT_NAME";
    public const string ErrorNameRequired = "ERROR_NAME_REQUIRED";
    public const string ErrorEmailRequired = "ERROR_EMAIL_REQUIRED";
    public const string ErrorInvalidEmail = "INVALID_EMAIL";
    public const string ErrorPhoneNumberRequired = "ERROR_PHONE_NUMBER_REQUIRED";
    public const string ErrorAddressRequired = "ERROR_ADDRESS_REQUIRED";
    public const string ErrorPartyIdRequired = "ERROR_PARTY_ID_REQUIRED";
    public const string ErrorOrganisationIdRequired = "ERROR_ORGANISATION_ID_REQUIRED";
  }

  public static class VirtualContactTypeName
  {
    public const string Name = "NAME";
    public const string Email = "EMAIL";
    public const string Phone = "PHONE";
    public const string Fax = "FAX";
    public const string Url = "WEB_ADDRESS";
  }

  public static class PatyType
  {
    public const string User = "USER";
    public const string NonUser = "NON_USER";
  }
}
