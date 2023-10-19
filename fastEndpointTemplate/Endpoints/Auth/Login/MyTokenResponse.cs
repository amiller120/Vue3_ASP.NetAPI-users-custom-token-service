using FastEndpoints.Security;

namespace fastEndpointTemplate.Endpoints.Auth.Login
{
    public class MyTokenResponse : TokenResponse
    {
        public string AccessTokenExpiray => AccessExpiry.ToLocalTime().ToString();

        public int RefreshTokenValidityMinutes => (int)RefreshExpiry.Subtract(DateTime.UtcNow).TotalMinutes;
    }
}