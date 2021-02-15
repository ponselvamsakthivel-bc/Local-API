using CcsSso.Domain.Constants;
using System.Text.RegularExpressions;

namespace CcsSso.Services.Helpers
{
  public static class UtilitiesHelper
  {
    public static bool IsEmailValid(string emailaddress)
    {
      Regex regex = new Regex(RegexExpressions.VALID_EMAIL_FORMAT_REGEX);
      Match match = regex.Match(emailaddress);
      return match.Success;
    }
  }
}
