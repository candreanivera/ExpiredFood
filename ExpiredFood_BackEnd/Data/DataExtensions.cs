using Microsoft.EntityFrameworkCore;

namespace ExpiredFood_BackEnd.Data
{
    public static class DataExtensions
    {
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ExpiredFood_BackEndContext>();
            dbContext.Database.Migrate();
        }
    }
}