using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Repository
{
    public interface IAdminRepository
    {
        List<UserDetails> ViewAdmins();
    }
}