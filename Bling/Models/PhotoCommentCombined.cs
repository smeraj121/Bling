using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class PhotoCommentCombined
    {
        public Photos photo { get; set; }
        public List<Comments> comments { get; set; }
    }
}