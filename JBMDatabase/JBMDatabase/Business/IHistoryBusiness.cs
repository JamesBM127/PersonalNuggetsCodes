namespace JBMDatabase.Business
{
    public interface IHistoryBusiness : IBaseBusiness
    {
        public Task<bool> AddHistoryAsync<TEntity>(TEntity entity, bool active = true) where TEntity : BaseHistoryEntity;
        public bool UpdateHistoryAsync<TEntity>(TEntity entity) where TEntity : BaseHistoryEntity;
        public bool DeleteSoftHistoryAsync<TEntity>(TEntity entity) where TEntity : BaseHistoryEntity;
        public bool SetActiveEntityHistory<TEntity>(TEntity entity, bool active = true) where TEntity : BaseHistoryEntity;
    }
}
