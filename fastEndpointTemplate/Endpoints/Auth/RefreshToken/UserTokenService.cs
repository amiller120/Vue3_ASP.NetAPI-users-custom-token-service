using FastEndpoints.Security;
using fastEndpointTemplate.Data.Contexts;
using fastEndpointTemplate.Endpoints.Auth.Login;

namespace fastEndpointTemplate.Endpoints.Auth.RefreshToken
{
    public class UserTokenService : RefreshTokenService<TokenRequest, MyTokenResponse>
    {
        private readonly DataContext _dataContext;

        public UserTokenService(IConfiguration config, DataContext dataContext)
        {
            _dataContext = dataContext;
            Setup(x =>
            {
                x.TokenSigningKey = config["JWTSigningKey"];
                x.AccessTokenValidity = TimeSpan.FromMinutes(1);
                x.RefreshTokenValidity = TimeSpan.FromHours(1);
                x.Endpoint("api/refresh-token", ep =>
                {
                    ep.Summary(s => s.Description = "this is the refresh token endpoint");
                });
            });
        }

        public override Task PersistTokenAsync(MyTokenResponse rsp)
        {
            _dataContext.RefreshTokens.Add(new Models.Data.RefreshToken { UserId = rsp.UserId, ExpiryDate = rsp.RefreshExpiry, Token = rsp.RefreshToken });
            _dataContext.SaveChanges();
            return Task.CompletedTask;
        }

        public override async Task RefreshRequestValidationAsync(TokenRequest req)
        {
            if(!await TokenIsValid(req.UserId, req.RefreshToken)){
                AddError("The refresh token is not valid!");
            }
        }

        public override async Task SetRenewalPrivilegesAsync(TokenRequest request, UserPrivileges privileges)
        {
            await Task.Delay(100); //simulate a db call
            privileges.Claims.Add(new("UserID", request.UserId));
            privileges.Permissions.AddRange(new Allow().AllCodes());
        }

        private Task<bool> TokenIsValid(string userId, string refreshToken)
        {
            var isTokenValid = _dataContext.RefreshTokens.Any(t =>
                                            t.UserId == userId &&
                                            t.Token == refreshToken &&
                                            t.ExpiryDate >= DateTime.UtcNow);
            return Task.FromResult(isTokenValid);
        }
    }
}
