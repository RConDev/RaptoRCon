using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RaptoRCon.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RaptoRConApiControllerBase : ApiController
    {
        public RaptoRConApiControllerBase()
        {
            var hubConnection = new HubConnection("http://localhost:10505/");
            this.MessageHubProxy = hubConnection.CreateHubProxy("MessageHub");
            hubConnection.Start().Wait();
        }

        protected IHubProxy MessageHubProxy { get; private set; }
    }
}
