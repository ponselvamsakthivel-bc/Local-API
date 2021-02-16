namespace CcsSso.Security.Domain.Dtos
{
  public class ApplicationConfigurationInfo
  {
    public AwsCognitoConfigurationInfo AwsCognitoConfigurationInfo { get; set; }

    public Auth0Configuration Auth0ConfigurationInfo { get; set; }

    public EmailConfigurationInfo EmailConfigurationInfo { get; set; }
  }

  public class Auth0Configuration
  {
    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string Domain { get; set; }

    public string DBConnectionName { get; set; }

    public string ManagementApiBaseUrl { get; set; }

    public string ManagementApiIdentifier { get; set; }

    public string DefaultDBConnectionId { get; set; }
  }

  public class AwsCognitoConfigurationInfo
  {
    public string AWSRegion { get; set; }

    public string AWSPoolId { get; set; }

    public string AWSAppClientId { get; set; }

    public string AWSAccessKeyId { get; set; }

    public string AWSAccessSecretKey { get; set; }

    public string AWSCognitoURL { get; set; }
  }

  public class EmailConfigurationInfo
  {
    public string ApiKey { get; set; }

    public string UserActivationEmailTemplateId { get; set; }

    public string ResetPasswordEmailTemplateId { get; set; }

    public int UserActivationLinkTTLInMinutes { get; set; }
  }
}
