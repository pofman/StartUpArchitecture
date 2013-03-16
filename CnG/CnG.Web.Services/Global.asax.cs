using System;
using System.Web;
using AutoMapper;
using CnG.Domain.Model;
using CnG.Services.Contracts.Dtos;

namespace CnG.Web.Services
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Mapper.CreateMap<User, UserContract>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(user => user.Membership.UserName));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}