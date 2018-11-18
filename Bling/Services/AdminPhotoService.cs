using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProofOfConcept.Models;
using ProofOfConcept.Repository;

namespace ProofOfConcept.Services
{
    public class AdminPhotoService : IAdminPhotoService
    {
        IAdminPhotoRepository ar;
        public AdminPhotoService(IAdminPhotoRepository ar) {
            this.ar = ar;
        }

        public bool EditPhoto(Photos photo)
        {
            try { return ar.EditPhoto(photo); }
            catch (Exception e) { }
            return false;
        }

        public List<Photos> GetFeatured()
        {
            try { return ar.GetFeatured(); }
            catch (Exception ex) { }
            return new List<Photos>();
        }

        public Photos GetPhoto(int photoId)
        {
            try { return ar.GetPhoto(photoId); }
            catch (Exception e) { }
            return new Photos();
        }

        public List<Photos> GetTrending()
        {
            try { return ar.GetTrending(); }
            catch (Exception e) { }
            return new List<Photos>();
        }

        public List<Photos> GetUploads()
        {
            try { return ar.GetUploads(); }
            catch (Exception e) { }
            return new List<Photos>();
        }
    }
}