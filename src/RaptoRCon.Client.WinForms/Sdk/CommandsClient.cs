using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Shared.Models;

namespace RaptoRCon.Client.WinForms.Sdk
{
    public class CommandsClient
    {
        public HttpClient HttpClient { get; private set; }

        public CommandsClient()
        {
            this.HttpClient = new HttpClient() {BaseAddress = new Uri("http://localhost:10505/api/command/")};
        }

        public async Task<CommandResult> SendAsync(Command command)
        {
            var response = await HttpClient.PostAsJsonAsync("command", command);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<CommandResult>();
        }
    }
}
