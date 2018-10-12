using ProofOfConcept.Models;
using System.Collections.Generic;

namespace ProofOfConcept.Repository
{
    public interface IPhotoStatsRepository
    {
        bool RecordStatistics(string email, int id, char action);
        PhotoStats PhotoDetails(int id);
        bool UpdateFame(PhotoStats newphotostat, PhotoStats currentPhotoStats);
    }
}