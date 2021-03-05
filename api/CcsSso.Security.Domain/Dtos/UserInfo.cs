using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CcsSso.Security.Domain.Dtos
{
  public class UserInfo
  {
    public string Id { get; set; }

    public string UserName { get; set; }

    [Required(ErrorMessage = Constants.Constants.ErrorCodes.EmailRequired)]
    [EmailAddressAttribute(ErrorMessage = Constants.Constants.ErrorCodes.EmailFormatError)]
    public string Email { get; set; }

    [Required(ErrorMessage = Constants.Constants.ErrorCodes.FirstNameRequired)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = Constants.Constants.ErrorCodes.LastNameRequired)]
    public string LastName { get; set; }

    public string Role { get; set; }

    public List<string> Groups { get; set; }

    public string ProfilePageUrl { get; set; }
  }
}
