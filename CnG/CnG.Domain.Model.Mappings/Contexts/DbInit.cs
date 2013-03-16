using System.Data.Entity;

namespace CnG.Domain.Model.Mappings.Contexts
{
    public class DbInit : DropCreateDatabaseIfModelChanges<EfContext>
    {
        protected override void Seed(EfContext context)
        {
            context.GetDbSet<User>().Add(new User
                {
                    FirstName = "Martin",
                    LastName = "Mendez",
                    Membership = new Membership
                        {
                            Password = "username",
                            UserName = "password"
                        }
                });

            base.Seed(context);
        }
    }
}