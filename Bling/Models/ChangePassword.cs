using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class ChangePassword
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        [RegularExpression("(^[a-zA-Z0-9!@#$%^&]{6,20}$)", ErrorMessage = "Password can contain alphabets, number or !,@,#,$,%,^,&.")]
        public string NewPassword { get; set; }

        [Required]
        [RegularExpression("(^[a-zA-Z0-9!@#$%^&]{6,20}$)", ErrorMessage = "Password can contain alphabets, number or !,@,#,$,%,^,&.")]
        [Compare("NewPassword", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}