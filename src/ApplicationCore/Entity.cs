using System;

namespace ApplicationCore
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? Modified { get; private set; }
    }
}
