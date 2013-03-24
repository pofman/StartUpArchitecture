using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public bool Authenticate(string userName, string password)
        {
            return _users.SingleOrDefault(x => x.Membership.Password == password && x.Membership.UserName == userName) != null;
        }

        public Guid Create(UserContract userContract)
        {
            var user = new User
                {
                    FirstName = userContract.FirstName,
                    LastName = userContract.LastName,
                    Membership = new Membership
                        {
                            Password = userContract.Password,
                            UserName = userContract.UserName
                        }
                };
            _users.Put(user);

            return user.Id;
        }

        public Guid Update(UserContract userContract)
        {
            var user = _users[userContract.Id];
            user.FirstName = userContract.FirstName;
            user.LastName = userContract.LastName;
            user.Membership.UserName = userContract.UserName;

            return user.Id;
        }

        public UserContract Get(Guid id)
        {
            return Mapper.Map<User, UserContract>(_users[id]);
        }

        public IEnumerable<UserContract> GetUsers()
        {
            return _users.Select(Mapper.Map<User, UserContract>);
        }
    }
}
