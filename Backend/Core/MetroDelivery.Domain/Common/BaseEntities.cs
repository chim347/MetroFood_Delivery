using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDelivery.Domain.Common
{
    public abstract class BaseEntities
    {
        public Guid Id { get; set; }
        private readonly List<BaseEvent> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
        public BaseEntities() => Id = Guid.NewGuid();
        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvent()
        {
            _domainEvents.Clear();
        }
    }
}
