namespace Contracts.Auth;

public record AuthResponse(string AccessToken, string? RefreshToken = null)
    : TokensResponse(AccessToken, RefreshToken)
{
    public UserInfo? UserInfo { get; init; }
}

public record TokensResponse(string AccessToken, string? RefreshToken = null);

public record UserInfo
{
    public string DisplayName { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
    public string DisplayRole { get; init; } = string.Empty;
    public string? PersonalSetting { get; init; }
}