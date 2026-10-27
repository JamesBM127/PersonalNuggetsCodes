using JBMDatabase;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DB_Test
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BaseHistoryEntityBuilder<BaseHistoryEntityTest>();
            modelBuilder.Entity<BaseHistoryEntityTest>(model =>
            {
                model.ToTable("BaseTest");
            });
        }
    }
}
