using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class UserAuth
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Word limit is 60 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Word limit is 20 characters.")]
        public string Password { get; set; }

        public string Role { get; set; }

        public int Verified { get; set; }

        public string Guid { get; set; }

        public string ForgotPassword { get; set; }
    }
}