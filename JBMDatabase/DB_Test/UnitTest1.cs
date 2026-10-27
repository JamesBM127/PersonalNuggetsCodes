using JBMDatabase.Enum;
using JBMDatabase.UnitOfWork;

namespace DB_Test
{
    public class Tests
    {
        TestContext Context;
        private IUoW UoW;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Server=.;Database=MinhaBase;User Id=sa;Password=sa123456;Encrypt=True;TrustServerCertificate=True;";
            Context = DB_Settings.GetAndCreateDbContext<TestContext>(DatabaseOptions.SqlServer, connectionString);
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
