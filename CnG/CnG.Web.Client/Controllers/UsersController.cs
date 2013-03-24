using System;
using System.Web.Mvc;
using CnG.Foundations.Mvc;

namespace CnG.Web.Client.Controllers
{
    public class UsersController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Create()
        {
            return View();
        }

        public ViewResult Update(Guid id)
        {
            return View();
        }

    }
}
