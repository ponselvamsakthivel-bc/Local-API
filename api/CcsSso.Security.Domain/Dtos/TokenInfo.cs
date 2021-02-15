using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CcsSso.Security.Domain.Dtos
{
  public class TokenRequestInfo
  {
    [JsonPropertyName("code")]
    public string Code { get; set; }

    public string RefreshToken { get; set; }

    //[Required]
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string RidirectUrl { get; set; }
  }

  public class TokenResponseInfo
  {
    public string AccessToken { get; set; }

    public string IdToken { get; set; }

    public string RefreshToken { get; set; }
  }

  public class Tokencontent
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("id_token")]
    public string IdToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
  }

  public class Auth0Tokencontent
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }
  }

  public class TicketInfo
  {
    [JsonProperty("ticket")]
    public string Ticket { get; set; }
  }
}
