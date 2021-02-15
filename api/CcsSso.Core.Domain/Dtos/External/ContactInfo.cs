using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CcsSso.Domain.Dtos.External
{
  public class ContactInfo
  {
    public string ContactReason { get; set; }

    public List<Contact> Contacts { get; set; }
  }

  public class Contact
  {
    public string ContactName { get; set; }

    public string ContactValue { get; set; }
  }

  public class ContactResponseInfo : ContactInfo
  {
    public int ContactId { get; set; }
  }

  public class OrganisationContactInfo : ContactResponseInfo
  {
    public string OrganisationId { get; set; }
  }

  public class UserContactInfo : ContactResponseInfo
  {
    public int UserId { get; set; }

    public string OrganisationId { get; set; }
  }
}
