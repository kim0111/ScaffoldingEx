using Ninject.Modules;
using ScaffoldingEx.Models;
using ScaffoldingEx.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ScaffoldingEx.Utils
{
    public class NinjectRegu : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeRepository>().To<HomeRepository>().WithConstructorArgument("dbEntities", new ModelAvenContext());
        }

    }
}