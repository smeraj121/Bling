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

        public List<Photos> RecentUploads(int? offset)
        {
            try {
                return pr.GetRecentUploads(offset);
            }
            catch(Exception e) { }
            return new List<Photos>();
        }

        public List<Photos> SearchPosts(string keyword) {
            try {
                return pr.SearchCaption(keyword.Substring(1));
            }
            catch (Exception e) { }
            return new List<Photos>();
        }

        public List<UserDetails> SearchUsers(string keyword)
        {
            try
            {
                return pr.SearchUser(keyword);
            }
            catch (Exception e) { }
            return new List<UserDetails>();
        }

        //public T Search<T>(string keyword)
        //{
        //    try
        //    {
        //        if(keyword.IndexOf('#')>-1)
        //            return (T)Convert.ChangeType(pr.SearchCaption(keyword), typeof(T)  );
        //        else
        //            return (T)Convert.ChangeType(pr.SearchUser(keyword), typeof(T));
        //    }
        //    catch (Exception e) { }
        //    return (T)Convert.ChangeType(new List<UserDetails>(), typeof(T));
        //}
    }
}