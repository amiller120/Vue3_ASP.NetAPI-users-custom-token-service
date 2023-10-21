using fastEndpointTemplate.Data.Contexts;

namespace fastEndpointTemplate.Endpoints.Register
{
    public class RegisterUser : Endpoint<RegisterRequest, RegisterResponse, RegisterMapper>
    {
        private readonly DataContext _dataContext;
        public RegisterUser(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override void Configure()
        {
            Post("api/auth/register");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
        {
            var newUser = Map.ToEntity(req);
            newUser.UserId = Guid.NewGuid().ToString(); // create guid for UserId
            _dataContext.Users.Add(newUser);
            try
            {
                var entriesWritten = _dataContext.SaveChanges();
                if (entriesWritten <= 0)
                {
                    ThrowError("User Creation failed");
                }

                Response.Message = $"The user {req.Name} has been Created Successfully.";
            }
            catch (Exception e)
            {

                throw;
            }
            await SendAsync(Response);
        }
    }
}
