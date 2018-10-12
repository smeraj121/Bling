using System;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUserDetailsRepository
    {
        UserDetails GetUserDetails(string email);
        object EditUserDetails(UserDetails user);
        string UploadPic(string path, string email);
    }
}