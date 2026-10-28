using JBMDatabase.UnitOfWork;

namespace JBMDatabase.Business
{
    public class HistoryBusiness : BaseBusiness, IHistoryBusiness
    {
        public HistoryBusiness(IUoW uow) : base(uow) { }

        public async Task<bool> AddHistoryAsync<TEntity>(TEntity entity, bool active = true) where TEntity : BaseHistoryEntity
        {
            DateTime now = DateTime.Now;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
            entity.HistoryType = Enum.HistoryType.Create;
            entity.Active = active;

            return await AddAsync(entity);
        }
    }
}
