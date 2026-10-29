using DB_Test.Entity;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;

namespace DB_Test
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BaseHistoryEntityBuilder<BaseEntityTest>();
            modelBuilder.Entity<BaseEntityTest>(model =>
            {
                model.ToTable("BaseTest");
            });
        }
    }
}
