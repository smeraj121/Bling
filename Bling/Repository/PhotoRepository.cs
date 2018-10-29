using ProofOfConcept.Models;
using ProofOfConcept.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        SqlConnection sqlConnection;
        public PhotoRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        public List<Photos> GetUploads(string email)
        {
            List<Photos> photos = new List<Photos>();
            SqlCommand cmd = new SqlCommand("Select * from AllPhotos where email=@email", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
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
                        Email = Convert.ToString(dr["Email"]),
                        PhotoPath = Convert.ToString(dr["PhotoPath"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["ContentType"]),
                        Thumbnail= Convert.ToString(dr["Thumnail"]),
                        Gif= Convert.ToString(dr["Gif"])
                    });
            }
            return photos;
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
                        Email = Convert.ToString(dr["Email"]),
                        PhotoPath = Convert.ToString(dr["PhotoPath"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c!="")?c:"0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"])
                    });
            }
            return photos;
        }

        public bool UploadPic(string path, string email,string caption, string filetype)
        {
            int i = 0;
            string dou = DateTime.Now.ToString("dd MMM, yyyy");
            SqlCommand cmd = new SqlCommand("insert into AllPhotos values(@email,@path,',',',',',',@caption,@dou,"+filetype+",NULL,NULL)", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@path", path);
            cmd.Parameters.AddWithValue("@caption", caption);
            cmd.Parameters.AddWithValue("@dou", dou);
            sqlConnection.Open();
            i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}