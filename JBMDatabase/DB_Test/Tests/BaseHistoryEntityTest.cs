using DB_Test.BusinessClass;
using DB_Test.Entity;
using JBMDatabase.Enum;
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

            BaseEntityTest entity2 = await Business.GetAsync<BaseEntityTest>(x => x.Id == entity.Id);

            Assert.That(saved, Is.True);
            Assert.That(entity2.HistoryType, Is.EqualTo(HistoryType.Update));
        }

        [Test]
        public async Task ActiveTrue_BaseHistoryBusiness_Sucess()
        {
            IReadOnlyCollection<BaseEntityTest> entities = await Business.ListAsync<BaseEntityTest>();
            BaseEntityTest? entity = entities.FirstOrDefault();

            bool setActiveTrue = Business.SetActiveEntityHistory(entity, true);
            bool saved = await Business.CommitAsync(setActiveTrue);

            BaseEntityTest entity2 = await Business.GetAsync<BaseEntityTest>(x => x.Id == entity.Id);

            Assert.That(saved, Is.True);
            Assert.That(entity.Active, Is.EqualTo(entity2.Active));
        }

        [Test]
        public async Task ActiveFalse_BaseHistoryBusiness_Sucess()
        {
            IReadOnlyCollection<BaseEntityTest> entities = await Business.ListAsync<BaseEntityTest>();
            BaseEntityTest? entity = entities.FirstOrDefault();
            
            bool setActiveFalse = Business.SetActiveEntityHistory(entity, false);
            bool saved = await Business.CommitAsync(setActiveFalse);

            BaseEntityTest entity2 = await Business.GetAsync<BaseEntityTest>(x => x.Id == entity.Id);

            Assert.That(saved, Is.True);
            Assert.That(entity.Active, Is.EqualTo(entity2.Active));
        }

        [Test]
        public async Task DeleteSoft_BaseHistoryBusiness_Sucess()
        {
            IReadOnlyCollection<BaseEntityTest> entities = await Business.ListAsync<BaseEntityTest>();
            BaseEntityTest? entity = entities.FirstOrDefault();
            
            bool deleted = Business.DeleteSoftHistoryAsync(entity);
            bool saved = await Business.CommitAsync(deleted);

            BaseEntityTest entity2 = await Business.GetAsync<BaseEntityTest>(x => x.Id == entity.Id);

            Assert.That(saved, Is.True);
            Assert.That(entity2.HistoryType, Is.EqualTo(HistoryType.Delete));
            Assert.That(entity2.Active, Is.EqualTo(false));
        }
    }
}
