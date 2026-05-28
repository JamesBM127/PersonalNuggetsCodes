using System.ComponentModel.DataAnnotations.Schema;

namespace JBMDatabase
{
    public abstract class NotMappedProperties : BaseHistoryEntity
    {
        [NotMapped]
        public int Counter { get; set; } = 1;
    }
}
