using JBM_PSSDB;
using Microsoft.EntityFrameworkCore;

namespace TEST_PSSDB
{
    public class PSSDB_Context : DbContext
    {
        public PSSDB_Context(DbContextOptions<PSSDB_Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.VaultEntityBuilder<VaultEntity>();
        }
    }
}
