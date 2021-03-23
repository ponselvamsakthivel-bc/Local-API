using CcsSso.Core.Domain.Contracts.External;
using CcsSso.Core.Domain.Dtos.External;
using CcsSso.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CcsSso.Core.Service.External
{
  public class ConfigurationDetailService : IConfigurationDetailService
  {
    private readonly IDataContext _dataContext;
    public ConfigurationDetailService(IDataContext dataContext)
    {
      _dataContext = dataContext;
    }
    public async Task<List<IdentityProviderDetail>> GetIdentityProvidersAsync()
    {
      var identityProviders = await _dataContext.IdentityProvider.Select(i => new IdentityProviderDetail
      {
        Id = i.Id,
        ConnectionName = i.IdpConnectionName,
        Name = i.IdpName
      }).ToListAsync();

      return identityProviders;
    }
  }
}