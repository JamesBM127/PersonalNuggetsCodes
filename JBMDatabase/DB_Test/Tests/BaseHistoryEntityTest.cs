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
            BaseEntityTest baseEntity = new();

            bool added = await Business.AddHistoryAsync(baseEntity);
            bool saved = await Business.CommitAsync(added);

            Assert.That(saved, Is.True);
        }

        [Test]
        public async Task Update_BaseHistoryBusiness_Sucess()
        {
            IReadOnlyCollection<BaseEntityTest> entities = await Business.ListAsync<BaseEntityTest>();
            BaseEntityTest? entity = entities.FirstOrDefault();
            entity.Active = !entity.Active;
            
            bool updated = Business.UpdateHistoryAsync(entity);
            bool saved = await Business.CommitAsync(updated);

            Assert.That(saved, Is.True);
        }
    }
}
