using Microsoft.AspNet.SignalR.Client;
using RaptoRCon.Server.Hosting;
using RaptoRCon.Server.Hosting.Exceptions;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RaptoRCon.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RaptoRConApiControllerBase : ApiController
    {
        protected IConnectionHost ConnectionHost { get; private set; }

        [ImportingConstructor]
        public RaptoRConApiControllerBase(IConnectionHost connectionHost)
        {
            this.ConnectionHost = connectionHost;
            var hubConnection = new HubConnection("http://localhost:10505/");
            this.MessageHubProxy = hubConnection.CreateHubProxy("MessageHub");
            hubConnection.Start().Wait();
        }

        protected IHubProxy MessageHubProxy { get; private set; }

        protected IHostedConnection GetHostedConnection(Guid connectionId)
        {
            IHostedConnection hostedConnection = null;
            try 
            {
                hostedConnection = ConnectionHost.Get(connectionId); 
            }
            catch(UnknownConnectionIdException ex) 
            {
                var response = new HttpResponseMessage(HttpStatusCode.RequestedRangeNotSatisfiable)
                {
                    Content = new ObjectContent<ExceptionMessage>(new ExceptionMessage() { Message = "The connection id was not available.", Reference = connectionId.ToString() }, new JsonMediaTypeFormatter())
                };

                throw new HttpResponseException(response);
            }

            return hostedConnection;
}
    }
}
