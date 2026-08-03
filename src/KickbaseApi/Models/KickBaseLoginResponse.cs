using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace KickBase.Api.Models;

public sealed class KickBaseLoginResponse
{
    [JsonPropertyName("emve")]
    public required string UserAccount { get; set; }
    
    [JsonPropertyName("u")]
    public required UserData User { get; set; }
    
    [JsonPropertyName("srvl")]
    public required KickBaseLeague[] Leagues { get; set; }
    
    [JsonPropertyName("tkn")]
    public required string Token { get; set; }
    
    [JsonPropertyName("tknex")]
    public required DateTime TokenExpiration { get; set; }
    
    [JsonPropertyName("chttkn")]
    public required string ChatToken { get; set; }
    
    [JsonPropertyName("chtknex")]
    public required DateTime ChatTokenExpiration { get; set; }
    
    [JsonPropertyName("isnu")]
    public required bool Isnu { get; set; }
    
    [JsonPropertyName("isnr")]
    public required bool Isnr { get; set; }
    
    [JsonPropertyName("emv")]
    public required bool EmailVerified { get; set; }
    
    [JsonPropertyName("emvr")]
    public required bool EmailVerifiedRequired { get; set; }
    
    [UsedImplicitly]
    public sealed class UserData
    {
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        
        [JsonPropertyName("notifications")]
        public required int Notifications { get; set; }
        
        [JsonPropertyName("gender")]
        public required int Gender { get; set; }
        
        [JsonPropertyName("flags")]
        public required int Flags { get; set; }
        
        [JsonPropertyName("vemail")]
        public required string VerifiedEmail { get; set; }
        
        [JsonPropertyName("enableBeta")]
        public required bool EnableBeta { get; set; }
        
        [JsonPropertyName("perms")]
        public required int[] Permissions { get; set; }
        
        [JsonPropertyName("id")]
        public required string UserId { get; set; }

        [JsonPropertyName("uim")]
        public required string UserImage { get; set; }
        
        [JsonPropertyName("profile")]
        public required string Profile { get; set; }
      
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        
        [JsonPropertyName("trialExpiry")]
        public required DateTime TrialExpiry { get; set; }
        
        [JsonPropertyName("mfacp")]
        public required int[] MfaCapabilities { get; set; }
        
        [JsonPropertyName("emv")]
        public required bool EmailVerified { get; set; }
        
        [JsonPropertyName("emvr")]
        public required bool EmailVerifiedRequired { get; set; }

    }
    
    [UsedImplicitly]
    public sealed class KickBaseLeague
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        
        [JsonPropertyName("cpi")]
        public required string Cpi { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }
        
        [JsonPropertyName("creator")]
        public required string Creator { get; set; }

        [JsonPropertyName("creatorId")]
        public required string CreatorId { get; set; }
        
        [JsonPropertyName("creation")]
        public required DateTime Creation { get; set; }
        
        [JsonPropertyName("ai")]
        public required double Ai { get; set; }
        
        [JsonPropertyName("t")]
        public required int T { get; set; }
        
        [JsonPropertyName("au")]
        public required int Au { get; set; }
        
        [JsonPropertyName("mu")]
        public required int Mu { get; set; }
        
        [JsonPropertyName("ap")]
        public required int Ap { get; set; }
        
        [JsonPropertyName("pub")]
        public required bool IsPublic { get; set; }
        
        [JsonPropertyName("gm")]
        public required int Gm { get; set; }
        
        [JsonPropertyName("mpl")]
        public required bool IsMpl { get; set; }
        
        [JsonPropertyName("pl")]
        public required int Player { get; set; }
        
        [JsonPropertyName("ci")]
        public required string CImage { get; set; }
        
        [JsonPropertyName("amd")]
        public required bool Amd { get; set; }
        
        [JsonPropertyName("vr")]
        public required int Version { get; set; }
        
        [JsonPropertyName("adm")]
        public required bool IsAdmin { get; set; }
        
        [JsonPropertyName("lim")]
        public required string LeagueImage { get; set; }

        [JsonPropertyName("uim")]
        public required string UserImage { get; set; }
    }
}

