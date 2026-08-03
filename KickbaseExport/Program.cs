using KickBase.Export;
using KickBase.Api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;
services.AddHostedService<KickBaseService>();
services.AddOptions<KickBaseApiOptions>()
    .BindConfiguration(KickBaseApiOptions.Section)
    .ValidateOnStart();
services.AddKickBaseApi();

var host = builder.Build();
host.Run();

