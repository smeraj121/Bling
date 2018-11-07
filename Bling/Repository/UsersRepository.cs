using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class UsersRepository:IUsersRepository
    {
        SqlConnection sqlConnection;
        public UsersRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        public UsersDetailsCombined GetUser(string email)
        {
            SqlCommand cmd = new SqlCommand("select top 10 * from UserDetails U, AllPhotos A where U.email=@email and A.email=@email", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            UsersDetailsCombined user = new UsersDetailsCombined();
            int i = 0;
            user.Photo = new List<Photos>();
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 0)
                    user.User = new UserDetails()
                    {
                        ProfilePic = Convert.ToString(dr["profilepic"]),
                        UserID = Convert.ToInt32(dr["Userid"]),
                        Email = Convert.ToString(dr["email"]),
                        Username = Convert.ToString(dr["username"]),
                        Name = Convert.ToString(dr["name"]),
                        Gender = Convert.ToString(dr["gender"]),
                        DOB = Convert.ToDateTime(dr["dob"]),
                        Bio = Convert.ToString(dr["bio"])
                    };

                user.Photo.Add(
                new Photos()
                {
                    PhotoID = Convert.ToInt32(dr["photoID"]),
                    Email = Convert.ToString(dr["Email"]),
                    PhotoPath = Convert.ToString(dr["PhotoPath"]),
                    LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    LovedBy = dr["LovedBy"].ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DOU = Convert.ToDateTime(dr["dou"]),
                    ContentType = Convert.ToString(dr["ContentType"]),
                    Thumbnail = Convert.ToString(dr["VideoThumbnail"]),
                    Gif = Convert.ToString(dr["VideoGif"])
                });
                i++;
            }
            return user;
        }

    }
}