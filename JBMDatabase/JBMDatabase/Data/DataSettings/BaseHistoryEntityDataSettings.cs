using Microsoft.EntityFrameworkCore;

namespace JBMDatabase.Data.DataSettings
{
    public static class BaseHistoryEntityDataSettings
    {
        public static void BaseHistoryEntityBuilder<TEntity>(this ModelBuilder modelBuilder, 
                                                                  bool dateRequired = true,
                                                                  bool historyRequired = true,
                                                                  bool activeRequired = true) where TEntity : BaseHistoryEntity
        {
            modelBuilder.BaseEntityModelBuilder<TEntity>();

            modelBuilder.Entity<TEntity>(model =>
            {
                model.Property(x => x.HistoryType)
                     .HasColumnName("History Type")
                     .HasColumnType("varchar(8)")
                     .HasColumnOrder(97)
                     .IsRequired(historyRequired);

                model.Property(x => x.CreatedAt)
                     .HasColumnName("CreatedAt")
                     .HasColumnOrder(98)
                     .IsRequired(dateRequired);

                model.Property(x => x.UpdatedAt)
                     .HasColumnName("UpdatedAt")
                     .HasColumnOrder(99)
                     .IsRequired(dateRequired);

                model.Property(x => x.Active)
                     .HasColumnName("Active")
                     .HasColumnOrder(100)
                     .IsRequired(dateRequired);
            });
        }
    }
}
