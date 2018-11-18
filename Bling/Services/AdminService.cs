using ProofOfConcept.Models;
using ProofOfConcept.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Services
{
    public class AdminService : IAdminService
    {
        AdminRepository adminRepository;
        public AdminService(AdminRepository adminRepository) {
            this.adminRepository = adminRepository;
        }
        public List<UserDetails> ViewAdmins(){
            try {
                return adminRepository.ViewAdmins();
            } catch { }
            return new List<UserDetails>();
        }
        public UserDetails ViewAdmin(int userId)
        {
            try
            {
                return adminRepository.ViewAdmins().First(m=>m.UserID==userId);
            }
            catch { }
            return new UserDetails();
        }
    }
}