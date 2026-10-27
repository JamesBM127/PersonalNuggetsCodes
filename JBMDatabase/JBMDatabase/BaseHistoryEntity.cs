using JBMDatabase.Enum;

namespace JBMDatabase
{
    public abstract class BaseHistoryEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public HistoryType HistoryType { get; set; }
    }
}
