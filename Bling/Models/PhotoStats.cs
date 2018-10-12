using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class PhotoStats
    {
        [Key]
        public int PhotoID { get; set; }

        public string LikedBy { get; set; }

        public string DisLikedBy { get; set; }

        public string LovedBy { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DOU { get; set; }

        public int Likes
        {
            get { return LikedBy.Split(',').Count() - 2; }
        }

        public int Dislikes
        {
            get { return DisLikedBy.Split(',').Count() - 2; }
        }

        public int Loves
        {
            get { return LovedBy.Split(',').Count() - 2; }
        }
    }
}