using CcsSso.Domain.Dtos.External;
using CcsSso.Dtos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CcsSso.Domain.Contracts
{
  public interface ICiiService
  {
    Task<CiiDto> GetAsync(string scheme, string companyNumber);

    Task<CiiSchemeDto[]> GetSchemesAsync();

    Task<string> PostAsync(CiiDto model);
  }
}
