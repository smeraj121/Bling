using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Services
{
    public interface IAdminUsersService
    {
        UserDetails GetUser(int userId);
        List<UserDetails> GetUsers();
        bool EditUser(UserDetails user);
        bool DeleteUser(int userId);
    }
}