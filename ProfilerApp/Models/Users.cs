using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProfilerApp.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Word limit is 50 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Word limit is 20 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Word limit is 20 characters.")]
        public int Username { get; set; }

        [Required]
        public int Name { get; set; }

        
        public string Gender { get; set; }

        [StringLength(100, ErrorMessage = "Word limit is 100 characters.")]
        [Display(Name = "BirthDay")]
        public DateTime DOB { get; set; }
    }
}