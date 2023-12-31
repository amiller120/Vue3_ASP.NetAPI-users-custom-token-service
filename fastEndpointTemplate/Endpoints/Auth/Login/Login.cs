﻿using FastEndpoints.Security;
using fastEndpointTemplate.Data.Contexts;
using fastEndpointTemplate.Endpoints.Auth.RefreshToken;
using fastEndpointTemplate.Helpers;
using Microsoft.AspNetCore.Authentication;

namespace fastEndpointTemplate.Endpoints.Auth.Login
{
    public class Login : Endpoint<LoginRequest, MyTokenResponse>
    {
        private readonly DataContext _dataContext;

        public Login(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override void Configure()
        {
            Post("api/auth/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Email.ToLower() == req.Email.ToLower());

            if (user == null || !PasswordHelper.VerifyPassword(req.Password, user.Password))
                ThrowError("Invalid user credentials!");
            
            Response = await CreateTokenWith<UserTokenService>(user.UserId, p =>
            {
                p.Claims.Add(new("UserID", user.UserId));
                p.Permissions.AddRange(new Allow().AllCodes());
            });
            HttpContext.Response.Cookies.Append("access_token", Response.AccessToken, new CookieOptions { HttpOnly = true });
        }
    }
}
