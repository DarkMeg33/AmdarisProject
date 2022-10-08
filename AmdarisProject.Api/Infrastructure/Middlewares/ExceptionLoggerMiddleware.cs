namespace AmdarisProject.Api.Infrastructure.Middlewares
{
    public class ExceptionLoggerMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger _logger;

        public ExceptionLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionLoggerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
