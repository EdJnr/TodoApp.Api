namespace Domain.Commons
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
