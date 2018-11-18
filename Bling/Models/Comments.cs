using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class Comments
    {
        public int CommentID { get; set; }
        public int PhotoID { get; set; }
        public string Text { get; set; }
        public string LikedBy { get; set; }
        public string LovedBy { get; set; }
        public string DislikedBy { get; set; }
        public int Likes { get { return LikedBy.Split(',').Count() - 2; } }
        public int Loves { get { return LovedBy.Split(',').Count() - 2; } }
        public int Dislikes { get { return DislikedBy.Split(',').Count() - 2; } }
    }
}