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
        public int AddUser(User user)
        {
            try
            {
                return userRepository.AddUser(user);
            }
            catch { }
            return 0;
        }

        public UserAuth AuthenticateUser(Login user)
        {
            try
            {
                return userRepository.AuthenticateUser(user);
            }
            catch (Exception ex) { }
            return new UserAuth();
        }
    }
}