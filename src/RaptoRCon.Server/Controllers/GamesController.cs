using RaptoRCon.Games;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RaptoRCon.Server.Controllers
{
    public class GamesController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<Game>> Get()
        {
            var gamesContext = GamesContext.GetInstance();
            var games = await gamesContext.GetAsync();
            return games.Select(
                game => new Game
                        {
                            Id = game.Id,
                            Name = game.Name,
                            Homepage = game.Homepage
                        });
        }

        [HttpGet]
        public async Task<Game> Get(Guid id)
        {
            var gamesContext = GamesContext.GetInstance();
            var game = await gamesContext.GetAsync(id);
            return new Game
            {
                Id = game.Id,
                Name = game.Name,
                Homepage = game.Homepage
            };
        }
    }
}
