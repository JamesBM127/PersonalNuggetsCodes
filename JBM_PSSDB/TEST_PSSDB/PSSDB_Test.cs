using JBMDatabase.Enum;
using JBMDatabase.UnitOfWork;

namespace TEST_PSSDB
{
    public class Tests
    {
        PSSDB_Context Context;
        private IUoW UoW;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Server=.;Database=TEST_PSSDB;User Id=sa;Password=sa123456;Encrypt=True;TrustServerCertificate=True;";
            Context = Settings_Test.GetAndCreateDbContext<PSSDB_Context>(DatabaseOptions.SqlServer, connectionString);
            UoW = new UoW(Context);
        }

        [TearDown]
        public void TearDown()
        {
            Context.Dispose();
        }

        [Test]
        public void CreateDB()
        {
            Assert.Pass();
        }

        [Test]
        public void DeleteDb()
        {
            Context.Database.EnsureDeleted();
            Assert.Pass();
        }
    }
}
