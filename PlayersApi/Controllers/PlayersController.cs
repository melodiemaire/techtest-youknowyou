using PlayersApi.Models;
using PlayersApi.Models.JsonContext;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PlayersApi.Controllers
{
    /// <summary>
    ///     A simple API to return tennis player stats.
    /// </summary>
    public class PlayersController : ApiController
    {
        private PlayersJsonContext _jsonContext;

        /// <summary>
        ///     Default constructor using json data file.
        /// </summary>
        public PlayersController() {
            _jsonContext = new PlayersJsonContext();
        }

        /// <summary>
        ///     Constructor for specific dataset of players (used for tests).
        /// </summary>
        /// <param name="players">List of players</param>
        public PlayersController(List<Player> players)
        {
            _jsonContext = new PlayersJsonContext(players);
        }

        /// <summary>
        ///     Get all tennis players ordered by Id.
        /// </summary>
        /// <returns>200 with all players</returns>
        public IHttpActionResult Get()
        {
            var players = _jsonContext.Players;
            return Ok(players.OrderBy(p => p.Id).ToList());
        }

        /// <summary>
        ///     Get tennis player specified by id (404 if id not exists).
        /// </summary>
        /// <param name="id">Player id</param>
        /// <returns>200 with player from id or 404 if not exists</returns>
        public IHttpActionResult Get(int id)
        {
            var players = _jsonContext.Players;
            if (!players.Any(p => p.Id == id))
                return NotFound();

            return Ok(players.Single(p => p.Id == id));
        }

        /// <summary>
        ///     Delete tennis player specified by id (404 if id not exists) and return all players.
        /// </summary>
        /// <param name="id">Player id</param>
        /// <returns>200 with all players after delete action or 404 if player with id not exists</returns>
        public IHttpActionResult Delete(int id)
        {
            var players = _jsonContext.Players;
            if (!players.Any(p => p.Id == id))
                return NotFound();
            
            var playerToRemove = players.Single(r => r.Id == id);
            players.Remove(playerToRemove);
            _jsonContext.SaveChanges();
            
            return Ok(players.OrderBy(p => p.Id).ToList());
        }
    }
}
