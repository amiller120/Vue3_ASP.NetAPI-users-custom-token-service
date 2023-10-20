using fastEndpointTemplate.Models.Data;

namespace fastEndpointTemplate.Endpoints.Register
{
    public class RegisterMapper : Mapper<RegisterRequest, RegisterResponse, Models.Data.User>
    {
        public override User ToEntity(RegisterRequest r) => new User
        {
            Email = r.Email,
            Password = r.Password,
            Name = r.Name,
        };
    }
}