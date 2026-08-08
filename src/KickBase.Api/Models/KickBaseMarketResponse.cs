using System.Text.Json.Serialization;
using JetBrains.Annotations;
using KickBase.Domain;

namespace KickBase.Api.Models;

[UsedImplicitly, KickBaseApi]
public sealed class KickBaseMarketResponse
{
    [JsonPropertyName("it")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required List<KickBaseMarketItem> Items { get; set; }

    [UsedImplicitly]
    public sealed class KickBaseMarketItem
    {
        [JsonPropertyName("i")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Id { get; set; }
        [JsonPropertyName("fn")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string FirstName { get; set; }
        [JsonPropertyName("n")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string LastName { get; set; }
        [JsonPropertyName("tid")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string TeamId { get; set; }
        [JsonPropertyName("pos")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Position { get; set; }
        [JsonPropertyName("st")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Status { get; set; }
        [JsonPropertyName("mvt")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required int Movement { get; set; } 
        [JsonPropertyName("mv")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int MarketValue { get; set; }
        [JsonPropertyName("ofc")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required int Ofc { get; set; }
        [JsonPropertyName("u")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public User? User { get; set; }
        [JsonPropertyName("prc")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Price { get; set; }
        [JsonPropertyName("isn")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required bool Isn { get; set; }
        [JsonPropertyName("iposl")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required bool Iposl { get; set; }
        [JsonPropertyName("dt")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required DateTime DateTime { get; set; }
        [JsonPropertyName("pim")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Image { get; set; }
        [JsonPropertyName("exs")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public int? ExpiresInSeconds { get; set; }

        [JsonIgnore]
        public string TransferEnds => ExpiresInSeconds is null
            ? "Keine Endzeitangabe"
            : SecondsToHHmm(ExpiresInSeconds.Value);
        
        private static string SecondsToHHmm(long totalSeconds)
        {
            var span = TimeSpan.FromSeconds(totalSeconds);
            var totalHours = (int)span.TotalHours;
            return $"{totalHours:D2}:{span.Minutes:D2}";
        }
    } 
    
    public sealed class User
    {
        [JsonPropertyName("i")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Id { get; set; }
        [JsonPropertyName("n")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Name { get; set; }
        [JsonPropertyName("uim")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Image { get; set; }
        [JsonPropertyName("isvf")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required bool IsVerified { get; set; }
        [JsonPropertyName("st")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Status { get; set; }
    }
}
