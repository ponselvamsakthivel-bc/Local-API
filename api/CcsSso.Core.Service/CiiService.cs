using CcsSso.DbModel.Entity;
using CcsSso.Domain.Constants;
using CcsSso.Domain.Contracts;
using CcsSso.Domain.Dtos;
using CcsSso.Domain.Exceptions;
using CcsSso.Dtos.Domain.Models;
using CcsSso.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CcsSso.Service
{
  public class CiiService : ICiiService
  {
    private HttpClient _client;

    public CiiService(HttpClient client)
    {
      _client = client;
    }

    /// <summary>
    /// Submits a json payload to CII
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<string> PostAsync(CiiDto model)
    {
      try
      {
        var body = Newtonsoft.Json.JsonConvert.SerializeObject(model);
        var response = await _client.PostAsync("/identities/schemes/organisation", new StringContent(body, System.Text.Encoding.UTF8, "application/json"));
        return await response.Content.ReadAsStringAsync();
      }
      catch (Exception ex)
      {
        Console.Write(ex);
        throw;
      }
    }

    /// <summary>
    /// Retrieves a payload from CII
    /// </summary>
    /// <param name="scheme"></param>
    /// <param name="companyNumber"></param>
    /// <returns></returns>
    public async Task<CiiDto> GetAsync(string scheme, string companyNumber)
    {
      try
      {
        using var responseStream = await _client.GetStreamAsync("/identities/schemes/organisation?scheme=" + scheme + "&id=" + companyNumber);
        return await JsonSerializer.DeserializeAsync<CiiDto>(responseStream);
      }
      catch (Exception ex)
      {
        Console.Write(ex);
        throw;
      }
    }

    /// <summary>
    /// Retrieves all the schemas from CII
    /// </summary>
    /// <returns></returns>
    public async Task<CiiSchemeDto[]> GetSchemesAsync()
    {
      try
      {
        using var responseStream = await _client.GetStreamAsync("/identities/schemes");
        return await JsonSerializer.DeserializeAsync<CiiSchemeDto[]>(responseStream);
      }
      catch (Exception ex)
      {
        Console.Write(ex);
        throw;
      }
    }

  }
}
