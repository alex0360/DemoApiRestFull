using System.Data.Entity.Core.Objects;

namespace Domain.Common
{
    public abstract class AuditableBaseModel
    {
        public virtual int? Id { get; set; }

        public virtual DateTime Created { get; set; }
        public virtual string CreatedBy { get; set; } = Environment.UserName;
        public virtual string CreatedOn { get; set; } = Environment.MachineName;

        public virtual DateTime? LastModified { get; set; }
        public virtual string? LastModifiedBy { get; set; } = Environment.UserName;
        public virtual string? LastModifiedOn { get; set; } = Environment.MachineName;

        public virtual ObjectParameter? ObjectParameter { get; set; }
    }
}