using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class Photos
    {
        [Key]
        public int PhotoID { get; set; }

        public int UserId { get; set; }

        public string ProfilePic { get; set; }

        public string Username { get; set; }

        public string PhotoPath{ get; set; }

        public string LikedBy { get; set; }

        public string DisLikedBy { get; set; }

        public string LovedBy { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Word limit is 500 characters.")]
        public string Caption { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DOU { get; set; }

        public int Likes { get { return LikedBy.Split(',').Count()-2;  } }

        public int Dislikes { get {return DisLikedBy.Split(',').Count()-2; } }

        public int Loves { get {return LovedBy.Split(',').Count()-2; } }

        public string ContentType { get; set; }

        public string Video { get; set; }

        public string Gif { get; set; }

    }
}