using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos.External;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.ExternalApi.Controllers
{
  [Route("user-profile")]
  [ApiController]
  public class UserProfileController : ControllerBase
  {
    private readonly IUserContactService _contactService;
    public UserProfileController(IUserContactService contactService)
    {
      _contactService = contactService;
    }

    /// <summary>
    /// Allows a user to create user contact details
    /// </summary>
    /// <response  code="200">Ok. Return created contact id</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_CONTACTS, INVALID_CONTACT_NAME, INVALID_EMAIL
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /user-profile/users/1/contact
    ///     {
    ///        "contactReason": "OTHER/BILLING/SHIPPING",
    ///        "Contacts": [
    ///         {
    ///           "contactName": "EMAIL",
    ///           "contactValue": "testuser@mail.com"
    ///         },
    ///         {
    ///           "contactName": "PHONE",
    ///           "contactValue": "9123454"
    ///         },
    ///         {
    ///           "contactName": "FAX",
    ///           "contactValue": "9123453"
    ///         },
    ///         {
    ///           "contactName": "WEB_ADDRESS",
    ///           "contactValue": "testuser.com"
    ///         }
    ///        ]
    ///     }
    ///     
    ///
    /// </remarks>
    [HttpPost("users/{userId}/contact")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(int), 200)]
    public async Task<int> CreateUserContact(int userId, ContactInfo contactInfo)
    {
      return await _contactService.CreateUserContactAsync(userId, contactInfo);
    }

    /// <summary>
    /// Allows a user to get user contact details
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /user-profile/users/1/contact
    ///     
    ///     
    ///
    /// </remarks>
    [HttpGet("users/{userId}/contact")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(List<UserContactInfo>), 200)]
    public async Task<List<UserContactInfo>> GetUserContactsList(int userId, [FromQuery] string contactType)
    {
      return await _contactService.GetUserContactsListAsync(userId, contactType);
    }

    /// <summary>
    /// Allows a user to retrieve details for a given contact
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="404">Not found</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /user-profile/users/1/contact/1
    ///     
    ///
    /// </remarks>
    [HttpGet("users/{userId}/contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(UserContactInfo), 200)]
    public async Task<UserContactInfo> GetUserContact(int userId, int contactId)
    {
      return await _contactService.GetUserContactAsync(userId, contactId);
    }


    /// <summary>
    /// Allows a user to edit user contact details
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_CONTACTS, INVALID_CONTACT_NAME, INVALID_EMAIL
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /user-profile/users/1/contact/1
    ///     {
    ///        "contactReason": "OTHER/BILLING/SHIPPING",
    ///        "Contacts": [
    ///         {
    ///           "contactName": "EMAIL",
    ///           "contactValue": "testuser@mail.com"
    ///         },
    ///         {
    ///           "contactName": "PHONE",
    ///           "contactValue": "9123454"
    ///         },
    ///         {
    ///           "contactName": "FAX",
    ///           "contactValue": "9123453"
    ///         },
    ///         {
    ///           "contactName": "WEB_ADDRESS",
    ///           "contactValue": "testuser.com"
    ///         }
    ///        ]
    ///     }
    ///     
    ///
    /// </remarks>
    [HttpPut("users/{userId}/contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(void), 200)]
    public async Task UpdateUserContact(int userId, int contactId, ContactInfo contactInfo)
    {
      await _contactService.UpdateUserContactAsync(userId, contactId, contactInfo);
    }

    /// <summary>
    /// Remove a contact from user
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /user-profile/users/1/contact/1
    ///     
    ///
    /// </remarks>
    [HttpDelete("users/{userId}/contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(void), 200)]
    public async Task DeleteUserContact(int userId, int contactId)
    {
      await _contactService.DeleteUserContactAsync(userId, contactId);
    }
  }
}
