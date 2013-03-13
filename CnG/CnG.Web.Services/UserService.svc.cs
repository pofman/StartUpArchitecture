using System.Linq;
using CnG.Domain.Model;
using CnG.Foundations.Persistence;
using CnG.Services.Contracts;
using CnG.Services.Contracts.Dtos;

namespace CnG.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private readonly IRepository<User> _users;

        public UserService(IRepository<User> users)
        {
            _users = users;
        }

        public bool Authenticate(AuthenticationDto authentication)
        {
            return _users.SingleOrDefault(x => x.Membership.Password == authentication.Password && x.Membership.UserName == authentication.UserName) != null;
        }
    }
}
