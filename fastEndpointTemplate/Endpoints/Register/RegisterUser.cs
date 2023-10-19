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
            Post("api/user/register");
            AllowAnonymous();
        }

        public override Task HandleAsync(RegisterRequest req, CancellationToken ct)
        {
            var newUser = Map.ToEntity(req);
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
            return base.HandleAsync(req, ct);
        }
    }
}
