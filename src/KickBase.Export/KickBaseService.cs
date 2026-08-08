using System.Globalization;
using CsvHelper;
using JetBrains.Annotations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KickBase.Api;
using Microsoft.Extensions.Options;

namespace KickBase.Export;

[UsedImplicitly]
internal sealed class KickBaseService : BackgroundService
{
    private readonly ILogger<KickBaseService> _logger;
    private readonly IKickBaseApiClient _apiClient;
    private readonly KickBaseApiOptions  _apiOptions;
    private readonly IHostApplicationLifetime _appLifetime;
    public KickBaseService(
        ILogger<KickBaseService> logger,
        IKickBaseApiClient apiClient,
        IOptions<KickBaseApiOptions> options,
        IHostApplicationLifetime appLifetime)
    {
        _logger = logger;
        _apiClient = apiClient;
        _apiOptions = options.Value;
        _appLifetime = appLifetime;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var session = await _apiClient.LoginAsync(_apiOptions.ToLoginRequest(), stoppingToken);
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
        var result = await _apiClient.GetMarketAsync(token, leagueId, stoppingToken); 
        if(result.Failed)
        {
            throw new Exception("Market not found");
        }

        await using (var writer = new StreamWriter("kickbaseExport.csv"))
        await using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            await csv.WriteRecordsAsync(result.ResultObject,  CancellationToken.None);
        }
        
        _appLifetime.StopApplication();
    }
    
}