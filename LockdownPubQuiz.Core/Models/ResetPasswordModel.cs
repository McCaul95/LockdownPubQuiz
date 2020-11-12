using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LockdownPubQuiz.Core.Models
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
    }
}
