using System;

namespace Provider.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get;  set; }
        public bool Active { get; protected set; }
    }
}
