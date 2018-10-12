using System;
using System.ComponentModel.DataAnnotations;

namespace ProfilerApp.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Word limit is 50 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Word limit is 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Word limit is 20 characters.")]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}