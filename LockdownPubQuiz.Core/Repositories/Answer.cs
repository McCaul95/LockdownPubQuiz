using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockdownPubQuiz.Core.Repositories
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AnswerText { get; set;}

        public int QuestionId { get; set; }

        public bool AnswerStatus { get; set; }

    }
}
