using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ProofOfConcept.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Services
{
    public class CloudinaryUploads
    {
        public static Account account = new Account("blinging", "686881248727483", "0Ef-kUMADLsoFzErvJyphSzsft0");
        static Cloudinary cloudinary = new Cloudinary(account);

        public static string UploadPicture(HttpPostedFileBase picture)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(picture.FileName, picture.InputStream),
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            if ((int)uploadResult.StatusCode >= 200 && (int)uploadResult.StatusCode <= 299)
            {
                string path = uploadResult.Uri.ToString();
                return path;
            }
            return "Not Found";
        }

        public static string UploadVideo(HttpPostedFileBase video)
        {
            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(video.FileName, video.InputStream)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            if ((int)uploadResult.StatusCode >= 200 && (int)uploadResult.StatusCode <= 299)
            {
                string path = uploadResult.Uri.ToString();
                return path;
            }
            return "Not Found";
        }

        internal static void DeletePreviousProfilePic(string result)
        {
            var deletefile = result.Split('/')[7].Split('.')[0];
            cloudinary.DeleteResources(deletefile);
        }
    }
}