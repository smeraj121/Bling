using System.Web;
using ProofOfConcept.Models;

namespace ProofOfConcept.Services
{
    public interface IUserDetailsService
    {
        UserDetails GetUser(string email);
        object EditUser(UserDetails user);
        bool UploadPic(HttpPostedFileBase profilePic,string userid);
    }
}