using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Repository
{
    public interface IAdminPhotoRepository
    {
        Photos GetPhoto(int photoId);
        List<Photos> GetUploads();
        List<Photos> GetFeatured();
        List<Photos> GetTrending();
        bool EditPhoto(Photos photo);
    }
}