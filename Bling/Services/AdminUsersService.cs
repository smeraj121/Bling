using ProofOfConcept.Models;
using ProofOfConcept.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Services
{
    public class AdminUsersService: IAdminUsersService
    {
        IAdminUsersRepository ar;
        public AdminUsersService(IAdminUsersRepository ar) {
            this.ar = ar;
        }

        public bool DeleteUser(int userId)
        {
            try {
                return ar.DeleteUser(userId);
            }
            catch (Exception e) { }
            return false;
        }

        public bool EditUser(UserDetails user)
        {
            try { return ar.EditUser(user); } catch (Exception e) { }return false;
        }

        public UserDetails GetUser(int userId)
        {
            try { return ar.GetUser(userId); }
            catch (Exception e) { }
            return new UserDetails();
        }

        public List<UserDetails> GetUsers()
        {
            try { return ar.GetUsers(); }
            catch (Exception e) { }
            return new List<UserDetails>();
        }
    }
}