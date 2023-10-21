using fastEndpointTemplate.Data.Contexts;

namespace fastEndpointTeamplateTest.Endpoints.Test
{
    public class Test : EndpointWithoutRequest<string>
    {
        private readonly DataContext _dbContext;

        public Test(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public override void Configure()
        {
            Get("/api/test");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var userId = User.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "userid")?.Value ?? "";
            if (!string.IsNullOrEmpty(userId) )
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
                Response = $"User logged in: {user?.Name}";
            }
            else
            {
                Response = "Fast Endpoints is working.";
            }
            
        }

    }
}
