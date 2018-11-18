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

        public UserDetails FollowUser(string email, string userid)
        {
            try
            {
                return usersRepository.FollowUser(email,userid);
            }
            catch (Exception e) { }
            return new UserDetails();
        }

        public UsersDetailsCombined GetUser(string email)
        {
            try
            {
                return usersRepository.GetUser(email);
            }
            catch (Exception e) { }
            return new UsersDetailsCombined();
        }
    }
}