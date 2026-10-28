namespace JBMDatabase.Business
{
    public interface IHistoryBusiness : IBaseBusiness
    {
        public Task<bool> AddHistoryAsync<TEntity>(TEntity entity, bool active = true) where TEntity : BaseHistoryEntity;
    }
}
