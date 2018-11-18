using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Services
{
    public interface IUsersService
    {
        UsersDetailsCombined GetUser(string email);
        UserDetails FollowUser(string email, string userid);
    }
}
