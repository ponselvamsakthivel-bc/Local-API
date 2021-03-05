using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos.External;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CcsSso.ExternalApi.Controllers
{
  [Route("users")]
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
    /// <response  code="404">Not found</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_USER_ID, INSUFFICIENT_DETAILS, INVALID_EMAIL, INVALID_PHONE_NUMBER
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /users/contact?userId=user@mail.com
    ///     {
    ///        "contactReason": "BILLING/SHIPPING",
    ///        "name": "Test User",
    ///        "email": "testuser@mail.com",
    ///        "phoneNumber": "+551155256325",
    ///        "fax": "9123453",
    ///        "webUrl": "testuser.com"
    ///     }
    ///     
    ///
    /// </remarks>
    [HttpPost("contact")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(int), 200)]
    public async Task<int> CreateUserContact(string userId, ContactInfo contactInfo)
    {
      return await _contactService.CreateUserContactAsync(userId, contactInfo);
    }

    /// <summary>
    /// Allows a user to get user contact details
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="404">Not found</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_USER_ID
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /user-profile/users/contact?userId=user@mail.com
    ///     
    ///     
    ///
    /// </remarks>
    [HttpGet("contact")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(UserContactInfoList), 200)]
    public async Task<UserContactInfoList> GetUserContactsList(string userId, [FromQuery] string contactType)
    {
      return await _contactService.GetUserContactsListAsync(userId, contactType);
    }

    /// <summary>
    /// Allows a user to retrieve details for a given contact
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="404">Not found</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_USER_ID
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /users/contact/1?userId=user@mail.com
    ///     
    ///
    /// </remarks>
    [HttpGet("contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(UserContactInfo), 200)]
    public async Task<UserContactInfo> GetUserContact(string userId, int contactId)
    {
      return await _contactService.GetUserContactAsync(userId, contactId);
    }


    /// <summary>
    /// Allows a user to edit user contact details
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="404">Not found</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_USER_ID, INSUFFICIENT_DETAILS, INVALID_EMAIL, INVALID_PHONE_NUMBER
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /users/contact/1?userId=user@mail.com
    ///     {
    ///        "contactReason": "BILLING/SHIPPING",
    ///        "name": "Test User",
    ///        "email": "testuser@mail.com",
    ///        "phoneNumber": "+551155256325",
    ///        "fax": "9123453",
    ///        "webUrl": "testuser.com"
    ///     }
    ///     
    ///
    /// </remarks>
    [HttpPut("contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(void), 200)]
    public async Task UpdateUserContact(string userId, int contactId, ContactInfo contactInfo)
    {
      await _contactService.UpdateUserContactAsync(userId, contactId, contactInfo);
    }

    /// <summary>
    /// Remove a contact from user
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="404">Not found</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_USER_ID
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /users/contact/1?userId=user@mail.com
    ///     
    ///
    /// </remarks>
    [HttpDelete("contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "User contact" })]
    [ProducesResponseType(typeof(void), 200)]
    public async Task DeleteUserContact(string userId, int contactId)
    {
      await _contactService.DeleteUserContactAsync(userId, contactId);
    }
  }
}
