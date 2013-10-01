using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Sockets;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Http.SelfHost;
using System.ComponentModel.Composition;

namespace RaptoRCon.Server.Config
{
    public static class MefConfig
    {
        internal static void RegisterMef(HttpSelfHostConfiguration config)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            var resolver = new MefDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }

   
}
