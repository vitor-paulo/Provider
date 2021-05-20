using System;

namespace Provider.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool Active { get; protected set; }
    }
}
