using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUsersRepository
    {
        UsersDetailsCombined GetUser(string email);
        UserDetails FollowUser(string email, string userId);
    }
}