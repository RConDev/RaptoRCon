using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Client.WinForms.Sdk
{
    public class GamesClient
    {
        public async Task<IEnumerable<Game>> GetAsync() 
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:10505/api/games") };
            var response = await httpClient.GetAsync(string.Empty);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<Game>>();
        } 
    }
}
