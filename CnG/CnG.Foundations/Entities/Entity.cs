using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnG.Foundations.Entities
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }

        protected Entity()
        {
            
        }
    }
}
