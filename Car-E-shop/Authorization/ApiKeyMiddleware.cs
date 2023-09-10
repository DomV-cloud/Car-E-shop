namespace Car_E_shop.Authorization
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var apiKey = context.Request.Headers["x-api-key"].FirstOrDefault();

            if (!string.IsNullOrEmpty(apiKey) && _configuration.GetSection("AllowedApiKeys").Get<string[]>()!.Contains(apiKey))
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized");
            }
        }
    }
}
