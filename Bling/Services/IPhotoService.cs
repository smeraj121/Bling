using System.Collections.Generic;
using System.Web;
using ProofOfConcept.Models;

namespace ProofOfConcept.Services
{
    public interface IPhotoService
    {
        bool UploadPic(HttpPostedFileBase picture, string userID,string caption);
        List<Photos> GetUploads(string userid);
        List<Photos> GetPhotos();
        Photos GetPhoto(int photoId);
        string[] GetRandomPics();
        bool SetTrending(int photoId);
        PhotoCommentCombined GetPhotoAndComments(int photoId);
    }
}