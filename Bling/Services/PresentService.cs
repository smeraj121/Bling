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
            return pr.GetFeatured();
        }
    }
}