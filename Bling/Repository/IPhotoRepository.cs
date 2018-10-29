using ProofOfConcept.Models;
using System.Collections.Generic;
using System.Web;

namespace ProofOfConcept.Repository
{
    public interface IPhotoRepository
    {
        bool UploadPic(string path, string email,string caption,string filetype);
        List<Photos> GetUploads();
        List<Photos> GetUploads(string email);
    }
}