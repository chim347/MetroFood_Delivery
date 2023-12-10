namespace MetroDelivery.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntities, ISoftDelete
    {
        public DateTime Created { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public bool IsDelete { get; set; }

        protected BaseAuditableEntity()
        {
            Created = DateTime.Now;
            IsDelete = false;
        }
    }
}
