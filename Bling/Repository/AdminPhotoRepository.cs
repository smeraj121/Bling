using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class AdminPhotoRepository:IAdminPhotoRepository
    {
        SqlConnection sqlConnection;
        public AdminPhotoRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        public Photos GetPhoto(int photoId)
        {
            Photos photo = new Photos();
            SqlCommand cmd = new SqlCommand("Select * from AllPhotos where photoid=@photoId", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@photoId", photoId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                photo = new Photos
                {
                    PhotoID = Convert.ToInt32(dr["photoID"]),
                    ProfilePic = Convert.ToString(dr["ProfilePic"]),
                    UserId=Convert.ToInt32(dr["userid"]),
                    PhotoPath = Convert.ToString(dr["Path"]),
                    LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DOU = Convert.ToDateTime(dr["dou"]),
                    ContentType = Convert.ToString(dr["ContentType"]),
                    Video = Convert.ToString(dr["Video"]),
                    Gif = Convert.ToString(dr["Gif"])
                };
            }
            return photo;
        }
        public List<Photos> GetUploads()
        {
            List<Photos> photos = new List<Photos>();
            SqlCommand cmd = new SqlCommand("Select * from AllPhotos", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                photos.Add(
                    new Photos
                    {
                        PhotoID = Convert.ToInt32(dr["photoID"]),
                        UserId = Convert.ToInt32(dr["userid"]),
                        ProfilePic = Convert.ToString(dr["Profilepic"]),
                        PhotoPath = Convert.ToString(dr["PhotoPath"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c!="")?c:"0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["contentType"])
                    });
            }
            return photos;
        }
        public List<Photos> GetFeatured()
        {
            List<Photos> photos = new List<Photos>();
            SqlCommand cmd = new SqlCommand("Select * from Feature f, allphotos a where f.photoid=a.photoid", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                photos.Add(
                    new Photos
                    {
                        PhotoID = Convert.ToInt32(dr["photoID"]),
                        UserId=Convert.ToInt32(dr["userid"]),
                        ProfilePic = Convert.ToString(dr["profilepic"]),
                        PhotoPath = Convert.ToString(dr["Path"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["ContentType"]),
                        Video = Convert.ToString(dr["Video"]),
                        Gif = Convert.ToString(dr["Gif"])
                    });
            }
            return photos;
        }
        public List<Photos> GetTrending()
        {
            List<Photos> photos = new List<Photos>();
            SqlCommand cmd = new SqlCommand("Select * from Trending t, allphotos a where t.photoid=a.photoid order by t.trendingorder", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                photos.Add(
                    new Photos
                    {
                        PhotoID = Convert.ToInt32(dr["photoID"]),
                        UserId = Convert.ToInt32(dr["userid"]),
                        ProfilePic = Convert.ToString(dr["profilepic"]),
                        PhotoPath = Convert.ToString(dr["Path"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["ContentType"]),
                        Video = Convert.ToString(dr["Video"]),
                        Gif = Convert.ToString(dr["Gif"])
                    });
            }
            return photos;
        }
        public bool EditPhoto(Photos photo) {
            SqlCommand cmd = new SqlCommand("update allphotos set caption=@caption where photoid=@photoId", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@photoId", photo.PhotoID);
            cmd.Parameters.AddWithValue("@caption", photo.Caption);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }
    }
}