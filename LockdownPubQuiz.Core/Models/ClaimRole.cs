using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LockdownPubQuiz.Core.Models
{
   

    public class ClaimRole
    {
        public string Name { get; set; }

        public int Claim { get; set; }
    }
}
