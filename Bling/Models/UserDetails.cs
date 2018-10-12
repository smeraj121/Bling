using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class UserDetails
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Word limit is 50 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Word limit is 20 characters.")]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Word limit is 250 characters.")]
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        public string ProfilePic { get; set; }
    }
}