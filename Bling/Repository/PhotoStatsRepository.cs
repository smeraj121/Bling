using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class PhotoStatsRepository : IPhotoStatsRepository
    {
        SqlConnection sqlConnection;
        public PhotoStatsRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        //public List<PhotoStats> GetAllPhotosStats()
        //{
        //    int i = 0;
        //    List<PhotoStats> photoStats = new List<PhotoStats>();
        //    SqlCommand cmd = new SqlCommand("Select * from PhotoStats ps, phoros p where  ps.PhotoID=p.PhotoID", sqlConnection);
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    sqlConnection.Open();
        //    sda.Fill(dt);
        //    sqlConnection.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        photoStats.Add(new PhotoStats
        //        {
        //            StatsId = Convert.ToInt32(dr["statsID"]),
        //            PhotoId = Convert.ToInt32(dr["PhotoId"]),
        //            LikedBy = Convert.ToString(dr["Liked"]),
        //            DislikedBy = Convert.ToString(dr["Disliked"]),
        //            LovedBy = Convert.ToString(dr["Loved"])
        //        });
        //    }
        //    return photoStats;
        //}

        public bool RecordStatistics(string email, int id, char action)
        {
            SqlCommand cmd = new SqlCommand("RecordAction", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@photoid", id);
            cmd.Parameters.AddWithValue("@action", action);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public PhotoStats PhotoDetails(int photoId)
        {
            PhotoStats photoStats = new PhotoStats();
            SqlCommand cmd = new SqlCommand("Select * from allPhotos where PhotoID=@pid", sqlConnection);
            cmd.Parameters.AddWithValue("@pid", photoId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
                photoStats = new PhotoStats
                {
                    PhotoID = Convert.ToInt32(dr["PhotoId"]),
                    LikedBy = Convert.ToString(dr["Likedby"]),
                    DisLikedBy = Convert.ToString(dr["Dislikedby"]),
                    LovedBy = Convert.ToString(dr["Lovedby"])
                };
            return photoStats;
        }

        public bool UpdateFame(PhotoStats newphotostat, PhotoStats currentPhotoStats)
        {
            SqlCommand cmd = new SqlCommand("RecordFame", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@todayLikes", newphotostat.Likes - currentPhotoStats.Likes);
            cmd.Parameters.AddWithValue("@todayDislikes", newphotostat.Dislikes- currentPhotoStats.Dislikes);
            cmd.Parameters.AddWithValue("@todayHearts", newphotostat.Loves - currentPhotoStats.Loves);
            cmd.Parameters.AddWithValue("@photoid", currentPhotoStats.PhotoID);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;

        }
    }
}