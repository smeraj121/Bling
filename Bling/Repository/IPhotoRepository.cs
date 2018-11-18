﻿using ProofOfConcept.Models;
using System.Collections.Generic;
using System.Web;

namespace ProofOfConcept.Repository
{
    public interface IPhotoRepository
    {
        bool UploadPic(string path, string email,string caption,string filetype);
        List<Photos> GetUploads();
        Photos GetPhoto(int photoId);
        List<Photos> GetUploads(string email);
        void SetTrending(int photoId);
        void CloseConnection();
        PhotoCommentCombined GetPhotoAndComments(int photoId);
    }
}