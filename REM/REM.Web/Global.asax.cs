using REM.Model.Entities;
using REM.Web.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace REM.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static List<User> Users;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            Users = new List<User>();
            var section = ConfigurationManager.GetSection("userSection");
            if (section != null)
            {
                var user = (section as UserSection).Users;
                for (int i = 0; i < user.Count; i++)
                {
                    Users.Add(new Model.Entities.User
                    {
                        Name= user[i].Name,
                        Login= user[i].Login,
                        Password = user[i].Password,
                    });
                }
            }
        }
    }
}
