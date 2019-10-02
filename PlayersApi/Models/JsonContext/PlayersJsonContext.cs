using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace PlayersApi.Models.JsonContext
{
    /// <summary>
    ///     Data context json for players.
    /// </summary>
    public class PlayersJsonContext
    {
        public List<Player> Players;
        private readonly string _jsonPath;

        /// <summary>
        ///     Create JsonContext. Read Json data file.
        /// </summary>
        public PlayersJsonContext() {
            _jsonPath = HostingEnvironment.MapPath("~/Content/headtohead.json");
            var jsonContent = File.ReadAllText(_jsonPath);
            this.Players = JsonConvert.DeserializeObject<RootObject>(jsonContent).Players;
        }

        /// <summary>
        ///     Create JsonContext from specific list of players (used for tests).
        /// </summary>
        public PlayersJsonContext(List<Player> players)
        {
            Players = players;
        }

        /// <summary>
        ///     Save changes to Json data file.
        /// </summary>
        public void SaveChanges()
        {
            var rootObject = new RootObject()
            {
                Players = this.Players
            };

            var jsonContent = JsonConvert.SerializeObject(rootObject);
            File.WriteAllText(_jsonPath, jsonContent);
        }
    }
}