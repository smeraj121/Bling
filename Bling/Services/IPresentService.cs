using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Services
{
    public interface IPresentService
    {
        List<Photos> Featured();
    }
}