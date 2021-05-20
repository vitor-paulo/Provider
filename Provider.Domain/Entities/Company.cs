using System;

namespace Provider.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; protected set; }
        public bool Active { get; protected set; }
    }
}
