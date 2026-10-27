using JBMDatabase;
using JBMDatabase.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DB_Test
{
    public static class DB_Settings
    {
        public static TContext GetAndCreateDbContext<TContext>(DatabaseOptions databaseOptions = DatabaseOptions.InMemoryDatabase,
                                                               string connectionString = "DbNameTeste") where TContext : DbContext
        {
            IServiceCollection service = new ServiceCollection();
            TContext dbContext = service.EnsureCreateAndGetDbContext<TContext>(connectionString, databaseOptions);

            return dbContext;
        }
    }
}
