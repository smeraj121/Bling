using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ProofOfConcept.Models;
using ProofOfConcept.Repository;

namespace ProofOfConcept.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        public static Account account = new Account("blinging", "686881248727483", "0Ef-kUMADLsoFzErvJyphSzsft0");
        Cloudinary cloudinary = new Cloudinary(account);
        IUserDetailsRepository userDetails;
        public UserDetailsService(IUserDetailsRepository userDetails)
        {
            this.userDetails = userDetails;
        }

        public object EditUser(UserDetails user)
        {
            try
            {
                if (user.Bio == null)
                    user.Bio = "";
                return userDetails.EditUserDetails(user);
            }
            catch { return new UserDetails(); }
        }

        public UserDetails GetUser(string email)
        {
            try
            {
                return userDetails.GetUserDetails(email);
            }
            catch(Exception e) { return new UserDetails(); }
        }

        public bool UploadPic(HttpPostedFileBase profilePic,string email)
        {
            try
            {
                string path = CloudinaryUploads.UploadPicture(profilePic);
                if (path != "Not Found")
                {
                    string result = userDetails.UploadPic(path, email);
                    if (result != "false")
                        CloudinaryUploads.DeletePreviousProfilePic(result);
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
            
        }
    }
}