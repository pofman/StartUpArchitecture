using System;
using System.Collections.Generic;
using System.Web.Http;
using CnG.Foundations.Mvc;
using CnG.Foundations.Wcf;
using CnG.Services.Contracts;
using CnG.Services.Contracts.Dtos;

namespace CnG.Web.Client.Controllers
{
    public class UsersApiController : BaseApiController
    {
        private readonly IServiceInvoker<IUserService> _usersService;

        public UsersApiController(IServiceInvoker<IUserService> usersService)
        {
            _usersService = usersService;
        }

        public IEnumerable<UserContract> GetUsers()
        {
            return _usersService.Invoke(x => x.GetUsers());
        }

        public UserContract GetUser(Guid id)
        {
            return _usersService.Invoke(x => x.Get(id));
        }

        [HttpPost]
        public object Create(UserContract userContract)
        {
            var userId = _usersService.Invoke(x => x.Create(userContract));
            return new
            {
                userId = userId
            };

        }

        [HttpPost]
        public object Update(UserContract userContract)
        {
            var userId = _usersService.Invoke(x => x.Update(userContract));
            return new
            {
                userId = userId
            };

        }
    }
}
