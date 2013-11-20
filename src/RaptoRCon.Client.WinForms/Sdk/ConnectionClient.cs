using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Shared.Models;

namespace RaptoRCon.Client.WinForms.Sdk
{
    public class ConnectionClient
    {
        public HttpClient HttpClient { get; private set; }

        public ConnectionClient()
        {
            this.HttpClient = new HttpClient() {BaseAddress = new Uri("http://localhost:10505/api/connection/")};
        }

        public async Task<IEnumerable<Connection>> GetAllAsync()
        {
            var response = await HttpClient.GetAsync(string.Empty);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<Connection>>();
        }

        public async Task<Connection> Get(Guid id)
        {
            var response = await HttpClient.GetAsync(id.ToString());
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Connection>();
        }

        public async Task<Connection> Disconnect(Guid id)
        {
            var response = await HttpClient.GetAsync(string.Format("{0}/disconnect", id));
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Connection>();
        }

        public async Task<Connection> Connect(Guid id)
        {
            var response = await HttpClient.GetAsync(string.Format("{0}/connect", id));
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Connection>();
        }
    }
}
