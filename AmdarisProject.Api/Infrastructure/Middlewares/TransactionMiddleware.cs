using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.Api.Infrastructure.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, DbContext dbContext)
        {
            if (context.Request.Method == HttpMethod.Get.Method)
            {
                await _next(context);
                return;
            }

            await using var transaction = await dbContext.Database.BeginTransactionAsync();

            await _next(context);

            await transaction.CommitAsync();
        }
    }
}
