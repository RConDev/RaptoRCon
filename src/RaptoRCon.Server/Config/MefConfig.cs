using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Sockets;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.ComponentModel.Composition;
using Owin;
using System.Web.Http;

namespace RaptoRCon.Server.Config
{
    public static class MefConfig
    {
        internal static void RegisterMef(HttpConfiguration config)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            var resolver = new MefDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }

   
}
