using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProofOfConcept.Models;
using ProofOfConcept.Repository;

namespace ProofOfConcept.Services
{
    public class UsersService : IUsersService
    {
        IUsersRepository usersRepository;
        public UsersService(IUsersRepository usersRepository) {
            this.usersRepository = usersRepository;
        }

        public bool BlockUser(string currentUser, string userId)
        {
            try { usersRepository.BlockUser(currentUser, userId);
                return true;
            }
            catch (Exception e) { }
            return false;
        }

        public UserDetails FollowUser(string email, string userid)
        {
            try
            {
                return usersRepository.FollowUser(email,userid);
            }
            catch (Exception e) { }
            return new UserDetails();
        }

        public UsersDetailsCombined GetUser(string user)
        {
            try
            {
                return usersRepository.GetUser(user);
            }
            catch (Exception e) { }
            return new UsersDetailsCombined();
        }
    }
}