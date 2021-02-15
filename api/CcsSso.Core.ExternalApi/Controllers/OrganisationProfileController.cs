using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos.External;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.ExternalApi.Controllers
{
  [Route("organisation-profile")]
  [ApiController]
  public class OrganisationProfileController : ControllerBase
  {
    private readonly IOrganisationContactService _contactService;
    public OrganisationProfileController(IOrganisationContactService contactService)
    {
      _contactService = contactService;
    }

    /// <summary>
    /// Allows a user to create organisation contact
    /// </summary>
    /// <response  code="200">Ok. Return created contact id</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_CONTACTS, INVALID_CONTACT_NAME, INVALID_EMAIL
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /organisation-profile/organisations/1/contact
    ///     {
    ///        "contactReason": "OTHER/BILLING/SHIPPING",
    ///        "Contacts": [
    ///         {
    ///           "contactName": "NAME",
    ///           "contactValue": "Test User"
    ///         },
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
    [HttpPost("organisations/{organisationId}/contact")]
    [SwaggerOperation(Tags = new[] { "Organisation contact" })]
    [ProducesResponseType(typeof(int),200)]
    public async Task<int> CreateOrganisationContact(string organisationId, ContactInfo contactInfo)
    {
      return await _contactService.CreateOrganisationContactAsync(organisationId, contactInfo);
    }

    /// <summary>
    /// Allows a user to get organisation contact details
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /organisation-profile/organisations/1/contact
    ///     
    ///     
    ///
    /// </remarks>
    [HttpGet("organisations/{organisationId}/contact")]
    [SwaggerOperation(Tags = new[] { "Organisation contact" })]
    [ProducesResponseType(typeof(List<OrganisationContactInfo>), 200)]
    public async Task<List<OrganisationContactInfo>> GetOrganisationContactsList(string organisationId, [FromQuery] string contactType)
    {
      return await _contactService.GetOrganisationContactsListAsync(organisationId, contactType);
    }

    /// <summary>
    /// Allows a user to retrieve details for a given organisation contact
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="404">Not found</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /organisation-profile/organisations/1/contact/1
    ///     
    ///
    /// </remarks>
    [HttpGet("organisations/{organisationId}/contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "Organisation contact" })]
    [ProducesResponseType(typeof(OrganisationContactInfo), 200)]
    public async Task<OrganisationContactInfo> GetOrganisationContact(string organisationId, int contactId)
    {
      return await _contactService.GetOrganisationContactAsync(organisationId, contactId);
    }

    /// <summary>
    /// Allows a user to edit organisation contact
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <response  code="400">Bad request.
    /// Error Codes: INVALID_CONTACTS, INVALID_CONTACT_NAME, INVALID_EMAIL
    /// </response>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /organisation-profile/organisations/1/contact/1
    ///     {
    ///        "contactReason": "OTHER/BILLING/SHIPPING",
    ///        "Contacts": [
    ///         {
    ///           "contactName": "NAME",
    ///           "contactValue": "Test User"
    ///         },
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
    [HttpPut("organisations/{organisationId}/contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "Organisation contact" })]
    [ProducesResponseType(typeof(void), 200)]
    public async Task UpdateOrganisationContact(string organisationId, int contactId, ContactInfo contactInfo)
    {
      await _contactService.UpdateOrganisationContactAsync(organisationId, contactId, contactInfo);
    }

    /// <summary>
    /// Remove a contact from an organisation
    /// </summary>
    /// <response  code="200">Ok</response>
    /// <response  code="401">Unauthorised</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /organisation-profile/organisations/1/contact/1
    ///     
    ///
    /// </remarks>
    [HttpDelete("organisations/{organisationId}/contact/{contactId}")]
    [SwaggerOperation(Tags = new[] { "Organisation contact" })]
    [ProducesResponseType(typeof(void), 200)]
    public async Task DeleteOrganisationContact(string organisationId, int contactId)
    {
      await _contactService.DeleteOrganisationContactAsync(organisationId, contactId);
    }


  }
}
