using JetBrains.Annotations;
using KickBase.Api.Models;
using Microsoft.Extensions.Configuration;

namespace KickBase.Api;

[UsedImplicitly]
public sealed class KickBaseApiOptions : IOptions
{
    public static string Section => "UserData";
    
    [ConfigurationKeyName("Username")]
    public required string Username { get; set; }
    [ConfigurationKeyName("Password")]
    public required string Password { get; set; }
    
    [ConfigurationKeyName("BaseUrl")]
    public required Uri BaseUrl { get; set; }
    
    [ConfigurationKeyName("ApiVersion")]
    public required string ApiVersion { get; set; }
    
    public KickBaseLoginRequest ToLoginRequest() => KickBaseLoginRequest.Create(Username, Password);
}

internal interface IOptions
{
    static abstract string Section { get; }
}