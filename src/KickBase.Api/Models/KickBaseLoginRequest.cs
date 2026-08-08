using System.Text.Json.Serialization;
using KickBase.Domain;

namespace KickBase.Api.Models;

[KickBaseApi]
public sealed class KickBaseLoginRequest
{
    [JsonPropertyName("em")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
    public required string Email { get; set; }

    [JsonPropertyName("pass")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
    public required string Password { get; set; }
    private KickBaseLoginRequest() { }
    
    public static KickBaseLoginRequest Create(string email, string password) => new ()
    {
        Email = email,
        Password = password
    };
    
}