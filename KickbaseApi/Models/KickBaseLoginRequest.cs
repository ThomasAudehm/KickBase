using System.Text.Json.Serialization;

namespace KickBase.Api.Models;

public sealed class KickBaseLoginRequest
{
    [JsonPropertyName("em")]
    public required string Email { get; set; }
    
    [JsonPropertyName("pass")]
    public required string Password { get; set; }
    private KickBaseLoginRequest() { }
    
    public static KickBaseLoginRequest Create(string email, string password) => new ()
    {
        Email = email,
        Password = password
    };
    
}