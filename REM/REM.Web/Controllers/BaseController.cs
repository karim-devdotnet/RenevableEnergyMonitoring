using REM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace REM.Web.Controllers
{
    public class BaseController : Controller
    {

        public bool DoLogin(LoginViewModel model)
        {
            if(Membership.Provider.ValidateUser(model.Login,model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe, "/");
                return true;
            }

            return false;
        }

        public void DoLogout()
        {
            FormsAuthentication.SignOut();
        }
    }
}