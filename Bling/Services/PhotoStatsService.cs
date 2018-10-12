using ProofOfConcept.Models;
using ProofOfConcept.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Services
{
    public class PhotoStatsService : IPhotoStatsService
    {
        IPhotoStatsRepository photoStatsRepository;
        public PhotoStatsService(IPhotoStatsRepository photoStatsRepository) {
            this.photoStatsRepository = photoStatsRepository;
        }
        public PhotoStats RecordStats(string email, int id,char action)
        {
            PhotoStats newphotostat=new PhotoStats();
            try {
                PhotoStats currentPhotoStats = photoStatsRepository.PhotoDetails(id);
                bool result = photoStatsRepository.RecordStatistics(email, id,action);
                if (result) {
                    newphotostat= photoStatsRepository.PhotoDetails(id);
                    photoStatsRepository.UpdateFame(newphotostat,currentPhotoStats);
                }
            }
            catch(Exception e) { }
            return newphotostat;
        }

    }
}