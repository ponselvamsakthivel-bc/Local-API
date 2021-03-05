using CcsSso.Domain.Contracts;
using CcsSso.Domain.Contracts.External;
using CcsSso.Domain.Dtos;
using CcsSso.Dtos.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CcsSso.Api.Controllers
{
  [Route("cii")]
  [ApiController]
  public class CiiController : ControllerBase
  {
    private readonly ICiiService _ciiService;
    public CiiController(ICiiService ciiService)
    {
      _ciiService = ciiService;
    }

    [HttpGet("{scheme}")]
    [SwaggerOperation(Tags = new[] { "cii" })]
    public async Task<CiiDto> Get(string scheme, [System.Web.Http.FromUri] string companyNumber)
    {
      return await _ciiService.GetAsync(scheme, companyNumber);
    }

    [HttpGet("GetSchemes")]
    [SwaggerOperation(Tags = new[] { "cii" })]
    public async Task<CiiSchemeDto[]> GetSchemes()
    {
      return await _ciiService.GetSchemesAsync();
    }

    [HttpPost]
    [SwaggerOperation(Tags = new[] { "cii" })]
    public async Task<string> Post(CiiDto model)
    {
      return await _ciiService.PostAsync(model);
    }
  }
}
