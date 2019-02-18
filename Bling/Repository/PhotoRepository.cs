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

        public Photos GetPhoto(int photoId)
        {
            Photos photo = new Photos();
            SqlCommand cmd = new SqlCommand("Select * from AllPhotos a, userdetails u where a.photoid=@photoId and u.userid=a.userid", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@photoId", photoId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                photo=new Photos{
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
                    };
            }
            return photo;
        }

        public List<Photos> GetUploads(string userid)
        {
            List<Photos> photos = new List<Photos>();
            SqlCommand cmd = new SqlCommand("Select * from AllPhotos a,userdetails u where a.userid=@userid and a.userid=u.userid", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
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
                        Username=Convert.ToString(dr["username"]),
                        ProfilePic = Convert.ToString(dr["profilepic"]),
                        PhotoPath = Convert.ToString(dr["Path"]),
                        LikedBy = (dr["LikedBy"]).ToString(),
                        DisLikedBy = (dr["DislikedBy"]).ToString(),
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType = Convert.ToString(dr["ContentType"]),
                        Video= Convert.ToString(dr["Video"]),
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
                        PhotoPath = Convert.ToString(dr["Path"]),
                        LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c!="")?c:"0")).ToArray()*/,
                        DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                        DOU = Convert.ToDateTime(dr["dou"]),
                        ContentType= Convert.ToString(dr["contentType"])
                    });
            }
            return photos;
        }

        public void SetTrending(int photoId)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("UpdateTrending", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@photoId", photoId);
            sqlConnection.Open();
            i = cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public bool UploadPic(string path, string userid,string caption, string filetype)
        {
            int i = 0;
            string dou = DateTime.Now.ToString("dd MMM, yyyy");
            string gif = "0";
            string thumbnail = "0";
            if (filetype == "Video") {
                string[] url = path.Split('/');
                url[6] = "so_0,eo_3,w_180,h_180,c_pad,b_black/e_loop"; url[url.Length - 1] = url[url.Length - 1].Split('.')[0]+".gif";
                gif = string.Join("/", url);
                url[6] = "w_180,h_180,c_pad,b_black"; url[url.Length - 1] = url[url.Length - 1].Split('.')[0] + ".jpg";
                thumbnail= string.Join("/", url);
            }
            SqlCommand cmd = new SqlCommand("UploadPic", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@path", (thumbnail != "0") ? thumbnail : path);
            cmd.Parameters.AddWithValue("@caption", caption);
            cmd.Parameters.AddWithValue("@dou", dou);
            cmd.Parameters.AddWithValue("@contenttype", filetype);
            cmd.Parameters.AddWithValue("@video", (thumbnail != "0")?path:thumbnail);
            cmd.Parameters.AddWithValue("@videogif", gif);
            sqlConnection.Open();
            i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public void CloseConnection() {
            sqlConnection.Close();
        }

        public PhotoCommentCombined GetPhotoAndComments(int photoId)
        {
            PhotoCommentCombined photo = new PhotoCommentCombined();
            SqlCommand cmd = new SqlCommand("select * from AllPhotos P Left join UserDetails U on U.Userid = P.userid Left join comments C on C.PhotoId = P.PhotoId where P.PhotoId = @photoId", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@photoId", photoId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sda.Fill(dt);
            sqlConnection.Close();
            int i = 0;
            photo.Comments = new List<Comments>();
            foreach (DataRow dr in dt.Rows)
            {
                if(i==0)
                photo.Photo = new Photos
                {
                    PhotoID = Convert.ToInt32(dr["photoID"]),
                    UserId = Convert.ToInt32(dr["userid"]),
                    Username=Convert.ToString(dr["username"]),
                    ProfilePic = Convert.ToString(dr["profilepic"]),
                    PhotoPath = Convert.ToString(dr["Path"]),
                    LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    LovedBy = (dr["LovedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DOU = Convert.ToDateTime(dr["dou"]),
                    ContentType = Convert.ToString(dr["ContentType"]),
                    Video = Convert.ToString(dr["Video"]),
                    Gif = Convert.ToString(dr["Gif"])
                };
                if ((dr["CommentID"]).ToString() != "") 
                photo.Comments.Add(new Comments() {
                    CommentID = Convert.ToInt32(dr["CommentID"]),
                    UserId=Convert.ToInt32(dr["userid"]),
                    PhotoID = Convert.ToInt32(dr["photoID"]),
                    ProfilePic =Convert.ToString(dr["profilepic"]),
                    Text=Convert.ToString(dr["text"]),
                    LikedBy=Convert.ToString(dr["likedby"]),
                    DislikedBy=Convert.ToString(dr["dislikedby"]),
                    LovedBy=Convert.ToString(dr["lovedby"])
                });
                i++;
            }
            return photo;
        }
    }
}