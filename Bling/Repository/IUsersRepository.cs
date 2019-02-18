using System.Collections.Generic;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public interface IUsersRepository
    {
        UsersDetailsCombined GetUser(string email);
        UserDetails FollowUser(string email, string userId);
        void BlockUser(string currentUser, string userId);
        List<UserDetails> GetBlockedUsers(string currentUser);
    }
}