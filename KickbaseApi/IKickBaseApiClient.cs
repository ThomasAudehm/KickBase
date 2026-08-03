using System.Net.Http.Headers;
using System.Net.Http.Json;
using KickBase.Api.Models;
using KickBase.Domain;
using Microsoft.Extensions.Options;

namespace KickBase.Api;

public interface IKickBaseApiClient
{
    Task<Result<KickBaseLoginResponse>> LoginAsync(KickBaseLoginRequest request, CancellationToken cancellationToken = default);
    Task<Result<KickBaseMarketResponse.KickBaseMarketItem[]>> GetMarketAsync(string token, string leagueId, CancellationToken cancellationToken = default);
}


internal class KickBaseApiClient : IKickBaseApiClient
{
    private readonly HttpClient _httpClient;
    private readonly KickBaseApiOptions _options;
    public KickBaseApiClient(
        HttpClient httpClient, 
        IOptions<KickBaseApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<Result<KickBaseLoginResponse>> LoginAsync(
        KickBaseLoginRequest request,
        CancellationToken cancellationToken = default) => 
        await _httpClient.PostAsJsonAsync($"/{_options.ApiVersion}/user/login", request, cancellationToken)
            .DeserializeToResultAsync<KickBaseLoginResponse>(options: null, cancellationToken);

    public async Task<Result<KickBaseMarketResponse.KickBaseMarketItem[]>> GetMarketAsync(string token, string leagueId, CancellationToken cancellationToken = default)
    {
        AddBearToken(token);
        var result = await  _httpClient.GetAsync($"/{_options.ApiVersion}/leagues/{leagueId}/market", cancellationToken: cancellationToken)
            .DeserializeToResultAsync<KickBaseMarketResponse>(options: null, cancellationToken);
        if (result.Failed)
        {
            return result.Error;
        }
        
        return result.ResultObject.Items.ToArray();
    }

    private void AddBearToken(string token)
    {
        _httpClient?.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}