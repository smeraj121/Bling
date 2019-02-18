using ProfilerApp.Models;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        UserAuth AuthenticateUser(Login user);
        bool ForgotPassword(string email, string guid);
        bool MatchGuid(string guid, string email);
        bool ChangePassword(ChangePassword changePasswordmodel, string email);
        bool SetPassword(SetPassword passwordmodel);
        void ResetForgotKey(string email);
    }
}