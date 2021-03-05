using CcsSso.Dtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CcsSso.Domain.Dtos
{

  public class UserDto
  {
    public int Id { get; set; }

    public string UserName { get; set; }

    public int Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string JobTitle { get; set; }

    public int PartyId { get; set; }

    public int OrganisationId { get; set; }
  }

  public class UserDetails
  {
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public List<UserGroup> UserGroups { get; set; }
  }

  public class UserGroup
  {
    public string Group { get; set; }

    public string Role { get; set; }
  }
}
