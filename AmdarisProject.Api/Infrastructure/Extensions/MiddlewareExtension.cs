using AmdarisProject.Api.Infrastructure.Middlewares;

namespace AmdarisProject.Api.Infrastructure.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseTransactions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransactionMiddleware>();
        }
    }
}
