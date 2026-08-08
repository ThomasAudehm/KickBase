using System.Text.Json.Serialization;
using JetBrains.Annotations;
using KickBase.Domain;

namespace KickBase.Api.Models;

[KickBaseApi, UsedImplicitly]
public sealed class KickBaseLoginResponse
{
    [JsonPropertyName("emve")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required string UserAccount { get; set; }
    
    [JsonPropertyName("u")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required UserData User { get; set; }
    
    [JsonPropertyName("srvl")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required KickBaseLeague[] Leagues { get; set; }
    
    [JsonPropertyName("tkn")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required string Token { get; set; }
    
    [JsonPropertyName("tknex")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required DateTime TokenExpiration { get; set; }
    
    [JsonPropertyName("chttkn")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required string ChatToken { get; set; }
    
    [JsonPropertyName("chtknex")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
    public required DateTime ChatTokenExpiration { get; set; }
    
    [JsonPropertyName("isnu")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
    public required bool Isnu { get; set; }
    
    [JsonPropertyName("isnr")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
    public required bool Isnr { get; set; }
    
    [JsonPropertyName("emv")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
    public required bool EmailVerified { get; set; }
    
    [JsonPropertyName("emvr")]
    [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
    public required bool EmailVerifiedRequired { get; set; }
    
    [UsedImplicitly,KickBaseApi]
    public sealed class UserData
    {
        [JsonPropertyName("email")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Email { get; set; }
        
        [JsonPropertyName("notifications")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Notifications { get; set; }
        
        [JsonPropertyName("gender")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Gender { get; set; }
        
        [JsonPropertyName("flags")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required int Flags { get; set; }
        
        [JsonPropertyName("vemail")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required string VerifiedEmail { get; set; }
        
        [JsonPropertyName("enableBeta")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required bool EnableBeta { get; set; }
        
        [JsonPropertyName("perms")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required int[] Permissions { get; set; }
        
        [JsonPropertyName("id")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string UserId { get; set; }

        [JsonPropertyName("uim")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string UserImage { get; set; }
        
        [JsonPropertyName("profile")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Profile { get; set; }
      
        [JsonPropertyName("name")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Name { get; set; }
        
        [JsonPropertyName("trialExpiry")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required DateTime TrialExpiry { get; set; }
        
        [JsonPropertyName("mfacp")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required int[] MfaCapabilities { get; set; }
        
        [JsonPropertyName("emv")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required bool EmailVerified { get; set; }
        
        [JsonPropertyName("emvr")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Guess)]
        public required bool EmailVerifiedRequired { get; set; }

    }
    
    [UsedImplicitly, KickBaseApi]
    public sealed class KickBaseLeague
    {
        [JsonPropertyName("id")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Id { get; set; }

        [JsonPropertyName("cpi")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required string Cpi { get; set; }

        [JsonPropertyName("name")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Name { get; set; }
        
        [JsonPropertyName("creator")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string Creator { get; set; }

        [JsonPropertyName("creatorId")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string CreatorId { get; set; }
        
        [JsonPropertyName("creation")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required DateTime Creation { get; set; }
        
        [JsonPropertyName("ai")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required double Ai { get; set; }
        
        [JsonPropertyName("t")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required int T { get; set; }
        
        [JsonPropertyName("au")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required int Au { get; set; }
        
        [JsonPropertyName("mu")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required int Mu { get; set; }
        
        [JsonPropertyName("ap")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required int Ap { get; set; }
        
        [JsonPropertyName("pub")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required bool IsPublic { get; set; }
        
        [JsonPropertyName("gm")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required int Gm { get; set; }
        
        [JsonPropertyName("mpl")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required bool IsMpl { get; set; }
        
        [JsonPropertyName("pl")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int TotalPlayerInLeague { get; set; }
        
        [JsonPropertyName("ci")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string CImage { get; set; }
        
        [JsonPropertyName("amd")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Unknown)]
        public required bool Amd { get; set; }
        
        [JsonPropertyName("vr")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required int Version { get; set; }
        
        [JsonPropertyName("adm")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required bool IsAdmin { get; set; }
        
        [JsonPropertyName("lim")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string LeagueImage { get; set; }

        [JsonPropertyName("uim")]
        [KickBasePropertyMeaning(KickbasePropertyMeaning.Verified)]
        public required string UserImage { get; set; }
    }
}

