using DB_Test.BusinessClass;
using DB_Test.Entity;
using JBMDatabase.UnitOfWork;

namespace DB_Test.Tests
{
    public class BaseHistoryEntityTest
    {
        TestContext Context;
        public HistoryBusinessTest Business;

        [SetUp]
        public void Setup()
        {
            GlobalTools.CreateUoW();
            Context = GlobalTools.Context;
            IUoW UoW = GlobalTools.GetUoW();
            Business = new(UoW);
        }

        [TearDown]
        public void TearDown()
        {
            Context.Dispose();
        }

        [Test]
        public async Task Add_BaseHistoryBusiness_Sucess()
        {
            DateTime now = DateTime.Now;

            BaseEntityTest baseEntity = new();

            bool added = await Business.AddHistoryAsync(baseEntity, false);
            bool saved = await Business.CommitAsync(added);

            Assert.That(saved, Is.True);
        }
    }
}
