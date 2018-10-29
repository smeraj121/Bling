using ProofOfConcept.Models;
using ProofOfConcept.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Services
{
    public class PhotoService : IPhotoService
    {
        IPhotoRepository photoRepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        public List<Photos> GetUploads(string email)
        {
            List<Photos> photos = new List<Photos>();
            try {
                //photos = photoRepository.GetUploads().FindAll(m => m.Email==email);
                photos = photoRepository.GetUploads(email);
            }
            catch(Exception e) { }
            return photos;
        }

        public List<Photos> GetPhotos() {
            List<Photos> photos = new List<Photos>();
            try
            {
                //photos = photoRepository.GetUploads().FindAll(m => m.Email==email);
                photos = photoRepository.GetUploads();
            }
            catch (Exception e) { }
            return photos;
        }

        public string[] GetRandomPics() {
            string[] images = new string[10];
            List<Photos> photos = GetPhotos();

            if (photos != null) {
                var allImages = photos.Select(m => m.PhotoPath).ToList();
                Random random = new Random();
                for(int i = 0;allImages.Count()>0 && i < 10; i++)
                {
                    int index =random.Next(0, allImages.Count);
                    images[i] = allImages[index];
                    //allImages.Remove(images[i]);
                }
            }
            return images;
        }

        public bool UploadPic(HttpPostedFileBase file, string email,string caption)
        {
            try {
                string path="Not Found";string filetype;
                if (file.ContentType.Contains("image"))
                { path = CloudinaryUploads.UploadPicture(file);
                    filetype = "image";
                }
                else
                { path = CloudinaryUploads.UploadVideo(file);
                    filetype = "video";
                }
                if (path != "Not Found")
                    {
                        bool result = photoRepository.UploadPic(path, email, caption,filetype);
                        if (result)
                            return true;
                    }
            }
            catch(Exception e) { }
            return false;
        }
    }
}