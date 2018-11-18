using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Services
{
    public interface IPresentService
    {
        List<Photos> Featured();
        List<Photos> Trending();
        List<Photos> RecentUploads(int? offset);
        List<Photos> SearchPosts(string keyword);
        List<UserDetails> SearchUsers(string keyword);
        //T Search<T>(string keyword);
    }
}