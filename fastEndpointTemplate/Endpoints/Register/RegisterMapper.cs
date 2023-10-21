using fastEndpointTemplate.Helpers;
using fastEndpointTemplate.Models.Data;

namespace fastEndpointTemplate.Endpoints.Register
{
    public class RegisterMapper : Mapper<RegisterRequest, RegisterResponse, Models.Data.User>
    {
        public override User ToEntity(RegisterRequest r)
        {
            return new User
            {
                Email = r.Email,
                Password = PasswordHelper.HashPassword(r.Password, out byte[] salt),
                Name = r.Name,
            };
        }
    }
}