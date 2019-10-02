using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayersApi.Controllers;
using PlayersApi.Models;

namespace PlayersApi.Tests
{
    [TestClass]
    public class PlayersApiUnitTest
    {
        [TestMethod]
        public void Get_ShouldReturnOkWithAllPlayers()
        {
            var mockPlayers = GetMockPlayers();
            var playersController = new PlayersController(mockPlayers);
            var response = playersController.Get() as OkNegotiatedContentResult<List<Player>>;
            Assert.IsNotNull(response);
            var players = response.Content;
            Assert.AreEqual(mockPlayers.Count(), players.Count());
        }

        [TestMethod]
        public void GetPlayer_ShouldReturnNotFoundIfWrongId()
        {
            var mockPlayers = GetMockPlayers();
            var playersController = new PlayersController(mockPlayers);
            var response = playersController.Get(12) as NotFoundResult;
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetPlayer_ShouldReturnOkWithPlayer()
        {
            var mockPlayers = GetMockPlayers();
            var playersController = new PlayersController(mockPlayers);
            var response = playersController.Get(1) as OkNegotiatedContentResult<Player>;
            Assert.IsNotNull(response);
            var player = response.Content;
            Assert.AreEqual(1, player.Id);
        }

        [TestMethod]
        public void DeletePlayer_ShouldReturnNotFoundIfWrongId()
        {
            var mockPlayers = GetMockPlayers();
            var playersController = new PlayersController(mockPlayers);
            var response = playersController.Delete(12) as NotFoundResult;
            Assert.IsNotNull(response);
        }

        /// <summary>
        ///     Get dataset of players for tests.
        /// </summary>
        /// <returns>List of players</returns>
        private List<Player> GetMockPlayers()
        {
            return new List<Player>()
            {
                new Player () { Id = 1, Firstname = "fn1", Lastname = "ln1"},
                new Player () { Id = 2, Firstname = "fn2", Lastname = "ln2"},
                new Player () { Id = 3, Firstname = "fn3", Lastname = "ln3"},
                new Player () { Id = 4, Firstname = "fn4", Lastname = "ln4"}
            };
        }
    }
}
