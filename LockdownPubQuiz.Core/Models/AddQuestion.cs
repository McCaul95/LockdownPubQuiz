using LockdownPubQuiz.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LockdownPubQuiz.Core.Models
{
    public class AddQuestion
    {
        public string Text { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
