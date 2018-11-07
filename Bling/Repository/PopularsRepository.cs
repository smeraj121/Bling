using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class PopularsRepository:IPopularsRepository
    {
        SqlConnection sqlConnection;
        public PopularsRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
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
                        Email = Convert.ToString(dr["Email"]),
                        PhotoPath = Convert.ToString(dr["PhotoPath"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["ContentType"]),
                        Thumbnail = Convert.ToString(dr["VideoThumbnail"]),
                        Gif = Convert.ToString(dr["VideoGif"])
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
                        Email = Convert.ToString(dr["Email"]),
                        PhotoPath = Convert.ToString(dr["PhotoPath"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["ContentType"]),
                        Thumbnail = Convert.ToString(dr["VideoThumbnail"]),
                        Gif = Convert.ToString(dr["VideoGif"])
                    });
            }
            return photos;
        }

        public List<Photos> GetRecentUploads(int? offset)
        {
            List<Photos> photos = new List<Photos>();
            SqlCommand cmd = new SqlCommand("GetRecent", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            if(offset!=null)
            cmd.Parameters.AddWithValue("@offset", offset);
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
                        Thumbnail = Convert.ToString(dr["VideoThumbnail"]),
                        Gif = Convert.ToString(dr["VideoGif"])
                    });
            }
            return photos.OrderByDescending(x => x.ContentType).ToList();
        }
    }
}