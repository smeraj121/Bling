using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProfilerApp.Models;
using ProofOfConcept.Models;
using ProofOfConcept.Repository;

namespace ProofOfConcept.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public bool AddUser(User user)
        {
            try
            {
                return userRepository.AddUser(user);
            }
            catch { return false; }
        }

        public int AuthenticateUser(UserAuth user)
        {
            int result = 0;
            try
            {
                result = userRepository.AuthenticateUser(user);
            }
            catch (Exception ex) { }
            return result;
        }
    }
}