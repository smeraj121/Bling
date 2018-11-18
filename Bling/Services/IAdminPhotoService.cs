using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Services
{
    public interface IAdminPhotoService
    {
        Photos GetPhoto(int photoId);
        List<Photos> GetUploads();
        List<Photos> GetFeatured();
        List<Photos> GetTrending();
        bool EditPhoto(Photos photo);
    }
}