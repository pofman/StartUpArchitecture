using System.Collections.Generic;
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
    }
}
