using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Repository
{
    public interface IAdminUsersRepository
    {
        UserDetails GetUser(int userId);
        List<UserDetails> GetUsers();
        bool EditUser(UserDetails user);
        bool DeleteUser(int userId);

    }
}