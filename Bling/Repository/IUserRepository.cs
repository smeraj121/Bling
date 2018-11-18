using ProfilerApp.Models;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        UserAuth AuthenticateUser(Login user);
    }
}