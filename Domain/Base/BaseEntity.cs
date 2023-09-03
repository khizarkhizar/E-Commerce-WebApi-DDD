using System.Collections.Generic;

namespace Domain.Base
{
    public   class BaseEntity
    {
        //public List<BaseDomainEvent> Event;

        ////public IReadOnlyList<BaseDomainEvent> Events => _events.AsReadOnly();

        //protected void AddEvent(BaseDomainEvent @event)
        //{
        //    Event.Add(@event);
        //}

        //protected void RemoveEvent(BaseDomainEvent @event)
        //{
        //    Event.Remove(@event);
        //}
        public BaseEntity()
        {
            EventId = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }

        public virtual Guid EventId { get; init; }
        public virtual DateTime CreatedOn { get; init; }
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; set; }
    }
}