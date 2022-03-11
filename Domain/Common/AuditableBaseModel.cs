namespace Domain.Common
{
    public abstract class AuditableBaseModel
    {
        public virtual int Id { get; set; }

        public virtual DateTime Created { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual string? CreatedOn { get; set; }

        public virtual DateTime? LastModified { get; set; }
        public virtual string? LastModifiedBy { get; set; }
        public virtual string? LastModifiedOn { get; set; }
    }
}