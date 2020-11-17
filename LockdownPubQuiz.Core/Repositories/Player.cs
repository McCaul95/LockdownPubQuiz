
using System.Collections.Generic;

namespace LockdownPubQuiz.Core.Repositories
{
    public class Player
    {
        public int Id { get; set; }

        public List<Game> ? PlayerGames { get; set; }
    }
}
