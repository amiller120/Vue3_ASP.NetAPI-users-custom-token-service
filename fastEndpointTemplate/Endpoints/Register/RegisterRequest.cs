using FastEndpoints;
using FluentValidation;

namespace fastEndpointTemplate.Endpoints.Register
{
    public class RegisterRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class Validator : Validator<RegisterRequest>
    {
        public Validator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).MinimumLength(5);
            RuleFor(x => x.Password).MinimumLength(5).MaximumLength(20);
        }
    }
}