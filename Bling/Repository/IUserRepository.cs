using ProfilerApp.Models;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        int AuthenticateUser(UserAuth user);
    }
}