using JBMDatabase;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;

namespace JBM_PSSDB
{
    public static class VaultEntityDataSettings
    {
        public static void VaultEntityBuilder<TEntity>(this ModelBuilder modelBuilder, bool dateRequired = true, bool historyRequired = true) where TEntity : BaseHistoryEntity
        {
            modelBuilder.BaseHistoryEntityBuilder<TEntity>();

            modelBuilder.Entity<VaultEntity>(model =>
            {
                model.ToTable("Vault");
                model.Property(p => p.Version).IsRequired();
                model.Property(p => p.Salt).IsRequired();
                model.Property(p => p.Pbkdf2Iterations).IsRequired();
                model.Property(p => p.EncryptedVaultKeyNonce).IsRequired();
                model.Property(p => p.EncryptedVaultKeyCiphertext).IsRequired();
                model.Property(p => p.EncryptedVaultKeyTag).IsRequired();
            });
        }
    }
}
