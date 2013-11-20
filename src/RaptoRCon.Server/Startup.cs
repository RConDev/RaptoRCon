using Owin;
using RaptoRCon.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace RaptoRCon.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            
            MefConfig.RegisterMef(config);
            
            app.UseWebApi(config);
            app.MapSignalR();
        }
    }
}
