using System.Collections.Generic;
using System.Web;
using ProofOfConcept.Models;

namespace ProofOfConcept.Services
{
    public interface IPhotoService
    {
        bool UploadPic(HttpPostedFileBase picture, string email,string caption);
        List<Photos> GetUploads(string email);
        List<Photos> GetPhotos();
        Photos GetPhoto(int photoId);
        string[] GetRandomPics();
        bool SetTrending(int photoId);
    }
}