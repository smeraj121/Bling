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

        public string Email { get; set; }

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

        public int Likes { get { /*if (LikedBy.Split(',')[0] == "") return LikedBy.Split(',').Count() - 2; else */return LikedBy.Split(',').Count()-2;  }
            /*get { if (LikedBy[0] != 0) return LikedBy.Count(); else return 0; }*/ }

        public int Dislikes { get {/* if (DisLikedBy.Split(',')[0] == "") return DisLikedBy.Split(',').Count() - 2; else */return DisLikedBy.Split(',').Count()-2; } 
        /*get { if (DisLikedBy[0] != 0) return DisLikedBy.Count(); else return 0; }*/ }

        public int Loves { get {/* if (LovedBy.Split(',')[0] == "") return LovedBy.Split(',').Count() - 2; else */return LovedBy.Split(',').Count()-2; }
            /*get { if (LovedBy[0] != 0) return LovedBy.Count(); else return 0; }*/ }
    }
}