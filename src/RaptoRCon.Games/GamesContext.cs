using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    public class GamesContext : IGamesContext
    {
        private CompositionContainer container;

        private GamesContext()
        {
            var catalog = new DirectoryCatalog(Path.Combine(Environment.CurrentDirectory, "games"));
            this.container = new CompositionContainer(catalog);
        }

        public async Task<IEnumerable<IGame>> GetAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                var exportedValues = this.container.GetExportedValues<IGame>();
                return exportedValues;
            });
        }

        public async Task<IGame> GetAsync(Guid id)
        {
            return await Task.Factory.StartNew(() =>
            {
                var exportedValues = this.container.GetExportedValues<IGame>();
                return exportedValues.FirstOrDefault(value => value.Id == id);
            });
        }

        public static IGamesContext GetInstance()
        {
            return new GamesContext();
        }
    }
}
