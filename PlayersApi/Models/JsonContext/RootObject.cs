using System.Collections.Generic;

namespace PlayersApi.Models.JsonContext
{
    /// <summary>
    ///     RootObject, used to (de)serialize Json data file.
    /// </summary>
    public class RootObject
    {
        public List<Player> Players { get; set; }
    }
}