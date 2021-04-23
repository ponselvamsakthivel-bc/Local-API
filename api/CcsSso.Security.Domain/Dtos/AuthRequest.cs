using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace CcsSso.Security.Domain.Dtos
{
  public class AuthRequest
  {
    [Required]
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [Required]
    [JsonPropertyName("password")]
    public string UserPassword { get; set; }

    [Required]
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("client_secret")]
    public string Secret { get; set; }
  }
}
