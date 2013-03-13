using CnG.Domain.Model.Mappings.Contexts;

namespace CnG.Domain.Model.Mappings
{
    public class UserConfiguration : BaseEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasRequired(x => x.Membership).WithRequiredDependent(x => x.User);
        }
    }
}
