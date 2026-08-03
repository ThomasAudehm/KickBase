using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace KickBase.Api.Models;

[UsedImplicitly]
public sealed class KickBaseMarketResponse
{
    [JsonPropertyName("it")]
    public required List<KickBaseMarketItem> Items { get; set; }
    
    [UsedImplicitly]
    public sealed class KickBaseMarketItem
    {
        [JsonPropertyName("i")]
        public required string Id { get; set; }
        [JsonPropertyName("fn")]
        public required string FirstName { get; set; }
        [JsonPropertyName("n")]
        public required string LastName { get; set; }
        [JsonPropertyName("tid")]
        public required string TeamId { get; set; }
        [JsonPropertyName("pos")]
        public required int Position { get; set; }
        [JsonPropertyName("st")]
        public required int Status { get; set; }
        [JsonPropertyName("mvt")]
        public required int Movement { get; set; } 
        [JsonPropertyName("mv")]
        public required int MarketValue { get; set; }
        [JsonPropertyName("ofc")]
        public required int Ofc { get; set; }
        [JsonPropertyName("u")]
        public User? User { get; set; }
        [JsonPropertyName("prc")]
        public required int Price { get; set; }
        [JsonPropertyName("isn")]
        public required bool Isn { get; set; }
        [JsonPropertyName("iposl")]
        public required bool Iposl { get; set; }
        [JsonPropertyName("dt")]
        public required DateTime DateTime { get; set; }
        [JsonPropertyName("pim")]
        public required string Image { get; set; }
    } 
    
    public sealed class User
    {
        [JsonPropertyName("i")]
        public required string Id { get; set; }
        [JsonPropertyName("n")]
        public required string Name { get; set; }
        [JsonPropertyName("uim")]
        public required string Image { get; set; }
        [JsonPropertyName("isvf")]
        public required bool IsVerified { get; set; }
        [JsonPropertyName("st")]
        public required int Status { get; set; }
    }
}
