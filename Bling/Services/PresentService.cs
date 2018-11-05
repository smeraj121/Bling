using ProofOfConcept.Models;
using ProofOfConcept.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Services
{
    public class PresentService:IPresentService
    {
        IPopularsRepository pr;
        public PresentService(IPopularsRepository pr) {
            this.pr = pr;
        }
        public List<Photos> Featured() {
            try
            {
                return pr.GetFeatured();
            }
            catch { }
            return new List<Photos>();
        }

        public List<Photos> Trending()
        {
            try { 
            return pr.GetTrending();
            }
            catch { }
            return new List<Photos>();
        }

        public List<Photos> RecentUploads()
        {
            try {
                return pr.GetRecentUploads();
            }
            catch(Exception e) { }
            return new List<Photos>();
        }
    }
}