using Autofac;
using Autofac.Integration.Mvc;
using ScaffoldingEx.Models;
using ScaffoldingEx.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ScaffoldingEx.Utils
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            /*builder.RegisterType<HomeRepository>().As<IHomeRepository>().WithParameter("dbcontext",new MyMusicDBEntities());*/
            builder.RegisterType<HomeRepository>().As<IHomeRepository>().WithParameters(new List<Parameter> { new NamedParameter("dbcontext", new ModelAvenContext()), new NamedParameter("conString", "vugbhdinjoa") });
            builder.RegisterType<HomeRepository>().As<IHomeRepository>().WithProperty("dbcontext", new ModelAvenContext());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}