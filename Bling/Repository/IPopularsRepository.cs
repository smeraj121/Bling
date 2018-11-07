using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Repository
{
    public interface IPopularsRepository
    {
        List<Photos> GetFeatured();
        List<Photos> GetTrending();
        List<Photos> GetRecentUploads(int? offset);
    }
}