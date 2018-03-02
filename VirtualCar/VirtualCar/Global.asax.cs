using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VirtualCar.Models;
using VirtualCar.Models.ModelsBinder;
using System.Web.Http;
using System.Net.Http.Formatting;

namespace VirtualCar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Using necesario para el routin del api 
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //ModelBinders para  el vitrtualCar en Session 
            ModelBinders.Binders.Add(typeof(VirtualCarModels), new VirtualCarModelBinder());
            //Archivos JSon
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());


        }
    }
}
