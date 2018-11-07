using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUsersRepository
    {
        UsersDetailsCombined GetUser(string email);
    }
}