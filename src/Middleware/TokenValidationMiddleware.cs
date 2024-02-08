using atdd_v2_dotnet.Controllers;

namespace atdd_v2_dotnet.Middleware;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/users/login"))
        {
            await _next.Invoke(context);
            return;
        }
        // Check if the token is present in the request headers
        if (context.Request.Headers.TryGetValue("Token", out var token))
        {
            // Validate the token here (e.g., check against a database or validate against a JWT)

            // If the token is valid, allow the request to continue
            if (IsValidToken(token))
            {
                await _next.Invoke(context);
                return;
            }
        }

        // If the token is missing or invalid, return a 401 Unauthorized response
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    }

    private bool IsValidToken(string? token)
    {
        // Implement your token validation logic here
        // Return true if the token is valid; otherwise, return false
        // Example: check the token against a database or validate against a JWT
        return Token.ValidToken(token);
    }
}