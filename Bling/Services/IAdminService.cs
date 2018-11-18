using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Services
{
    public interface IAdminService
    {
        List<UserDetails> ViewAdmins();
        UserDetails ViewAdmin(int userId);
    }
}