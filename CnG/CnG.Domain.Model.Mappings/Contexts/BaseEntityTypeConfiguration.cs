using System.Data.Entity.ModelConfiguration;

namespace CnG.Domain.Model.Mappings.Contexts
{
    public abstract class BaseEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        protected BaseEntityTypeConfiguration()
        {
            MapId();
        }

        protected virtual void MapId()
        {
            HasKey(x => x.Id);
        }
    }
}
