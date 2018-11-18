using ProfilerApp.Models;
using ProofOfConcept.Models;

namespace ProofOfConcept.Services
{
    public interface IUserService
    {
        int AddUser(User user);
        UserAuth AuthenticateUser(Login user);
    }
}