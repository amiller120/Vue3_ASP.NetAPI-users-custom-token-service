using fastEndpointTemplate.Data.Contexts;

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

            if (user == null)
                ThrowError("Invalid user credentials!");

            //Response = await CreateTokenWith<RefreshToken.UserTokenService>(user.Id.ToString(), p =>
            //{
            //    p.Claims.Add(new("UserID", user.Id.ToString()));
            //    p.Permissions.AddRange(new Allow().AllCodes());
            //});
        }
    }
}
