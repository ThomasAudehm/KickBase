using JetBrains.Annotations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KickBase.Api;
using Microsoft.Extensions.Options;

namespace KickBase.Export;

[UsedImplicitly]
internal sealed class KickBaseService : IHostedService
{
    private readonly ILogger<KickBaseService> _logger;
    private readonly IKickBaseApiClient _apiClient;
    private readonly KickBaseApiOptions  _apiOptions;
    public KickBaseService(
        ILogger<KickBaseService> logger,
        IKickBaseApiClient apiClient,
        IOptions<KickBaseApiOptions> options)
    {
        _logger = logger;
        _apiClient = apiClient;
        _apiOptions = options.Value;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var session = await _apiClient.LoginAsync(_apiOptions.ToLoginRequest(), cancellationToken);
        if (session.Failed)
        {
            throw new Exception("Login failed");
        }
        var token = session.ResultObject.Token;
        var leagueId = session.ResultObject.Leagues.Where(x => x.Name == "ErsteBaum").Select(x => x.Id).FirstOrDefault();
        if (leagueId == null)
        {
            throw new Exception("League not found");
        }
        var result = await _apiClient.GetMarketAsync(token, leagueId, cancellationToken); 
        if(result.Failed)
        {
            throw new Exception("Market not found");
        }

        foreach (var player in result.ResultObject)
        {
            Console.WriteLine($"Name: {player.FirstName} {player.LastName} , Position: {player.Position}, MarketValue: {player.MarketValue}, Price: {player.Price}");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}