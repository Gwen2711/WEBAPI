public class RoleMiddleware
{
    private readonly RequestDelegate _next;

    public RoleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var role = context.Request.Headers["Role"].ToString();

        if (role == "admin" || role == "user")
        {
            context.Items["Role"] = role; // добавляем роль в контекст
        }
        
        await _next(context);
    }
}