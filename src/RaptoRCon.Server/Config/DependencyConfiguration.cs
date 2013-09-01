using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using RaptoRCon.Sockets;

namespace RaptoRCon.Server.Config
{
    public static class DependencyConfiguration
    {
        public static IContainer BuildUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof (DependencyConfiguration).Assembly);
            builder.RegisterType<ConnectionHost>().AsSelf().SingleInstance();
            return builder.Build();
        }
    }

    public class ConnectionHost
    {
        public ISocket Socket { get; set; }
    }
}
