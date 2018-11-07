using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class UsersDetailsCombined
    {
        public UserDetails User { set; get; }
        public List<Photos> Photo{ get; set; }
    }
}