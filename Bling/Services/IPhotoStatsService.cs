using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Services
{
    public interface IPhotoStatsService
    {
        PhotoStats RecordStats(string email, int id,char action);
    }
}