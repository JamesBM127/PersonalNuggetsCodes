using JBMDatabase;
using JBMDatabase.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TEST_PSSDB
{
    public static class Settings_Test
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
