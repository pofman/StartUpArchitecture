using System;
using CnG.Foundations.Entities;

namespace CnG.Domain.Model
{
    public abstract class Entity : Entity<Guid>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
