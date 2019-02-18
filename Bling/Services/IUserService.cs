using ProfilerApp.Models;
using ProofOfConcept.Models;

namespace ProofOfConcept.Services
{
    public interface IUserService
    {
        int AddUser(User user);
        UserAuth AuthenticateUser(Login user);
        bool ForgotPassword(string email);
        bool MatchGuid(string guid, string email);
        bool SetPassword(SetPassword setPassword);
        bool ChangePassword(ChangePassword changePassword,string userid);
    }
}