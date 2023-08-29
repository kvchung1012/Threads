using System.ComponentModel.DataAnnotations;

namespace Threads.IdentityService.Domain.Core.Primitives
{
    public abstract class EntityBase<TKey>
    {
        public EntityBase()
        {
            
        }

        public TKey Id { get; private set; } = default!;
        public DateTime? CreatedOnUtc { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class EntityBase : EntityBase<Guid>
    {
        
    }
}
