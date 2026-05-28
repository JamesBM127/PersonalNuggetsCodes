using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBMDatabase
{
    public abstract class BaseEntity : ICloneable
    {
        [Key]
        public Guid Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
