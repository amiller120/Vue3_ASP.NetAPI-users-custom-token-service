public class AuthorizationHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var jwtCookie = context.Request.Cookies["access_token"];

        if (!string.IsNullOrEmpty(jwtCookie))
        {
            context.Request.Headers.Add("Authorization", $"Bearer {jwtCookie}");
        }

        await _next(context);
    }
}