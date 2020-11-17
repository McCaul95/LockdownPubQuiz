using LockdownPubQuiz.Core.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockdownPubQuiz.Core
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Difficulty { get; set; }

        public List<Question> Questions { get; set; }

        public List<Player> Players { get; set; }

    }
}
