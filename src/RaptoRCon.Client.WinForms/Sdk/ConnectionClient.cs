using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RaptoRCon.Shared.Commands;
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

        public async Task<ConnectionCreated> CreateAsync(CreateConnectionCommand createConnectionCommand)
        {
            var response = await HttpClient.PostAsJsonAsync("connection", createConnectionCommand);
            response.EnsureSuccessStatusCode();

            var connectionCreated = await response.Content.ReadAsAsync<ConnectionCreated>();
            return connectionCreated;
        }

        public async Task<IEnumerable<Connection>> GetAllAsync()
        {
            var response = await HttpClient.GetAsync(string.Empty);
            response.EnsureSuccessStatusCode();

            var connections = await response.Content.ReadAsAsync<IEnumerable<Connection>>();
            return connections;
        }

        public async Task<Connection> GetAsync(Guid id)
        {
            var response = await HttpClient.GetAsync(id.ToString());
            response.EnsureSuccessStatusCode();

            var connection = await response.Content.ReadAsAsync<Connection>();
            return connection;
        }

        public async Task<Connection> DisconnectAsync(Guid id)
        {
            var response = await HttpClient.GetAsync(string.Format("{0}/disconnect", id));
            response.EnsureSuccessStatusCode();

            var connection = await response.Content.ReadAsAsync<Connection>();
            return connection;
        }

        public async Task<Connection> ConnectAsync(Guid id)
        {
            var response = await HttpClient.GetAsync(string.Format("{0}/connect", id));
            response.EnsureSuccessStatusCode();

            var connection = await response.Content.ReadAsAsync<Connection>();
            return connection;
        }
    }
}
