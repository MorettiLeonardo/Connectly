namespace Connectly.Domain.DomainObjects
{
    public abstract class AggregateRoot : BaseEntity
    {
        public AggregateRoot()
        {
            Id = Guid.NewGuid();
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
