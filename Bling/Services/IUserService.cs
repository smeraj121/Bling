using ProfilerApp.Models;
using ProofOfConcept.Models;

namespace ProofOfConcept.Services
{
    public interface IUserService
    {
        bool AddUser(User user);
        int AuthenticateUser(UserAuth user);
    }
}