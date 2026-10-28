using JBMDatabase.Enum;
using JBMDatabase.UnitOfWork;

namespace DB_Test.Tests
{
    public class Tests
    {
        TestContext Context;
        private IUoW UoW;

        [SetUp]
        public void Setup()
        {
            GlobalTools.CreateUoW();
            Context = GlobalTools.Context;
            UoW = GlobalTools.GetUoW();
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
