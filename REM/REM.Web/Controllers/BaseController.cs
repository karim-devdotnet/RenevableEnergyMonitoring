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

        protected override void OnException(ExceptionContext filterContext)
        {
            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception,
                filterContext.RouteData.Values["controller"] as string,
                filterContext.RouteData.Values["action"] as string);

            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewData = new ViewDataDictionary(model)
            };

            filterContext.ExceptionHandled = true;
        }
    }
}