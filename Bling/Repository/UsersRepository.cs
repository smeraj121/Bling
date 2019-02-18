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

        public void BlockUser(string currentUser, string userId)
        {
            SqlCommand cmd = new SqlCommand("BlockUser", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@currentuser", currentUser);
            cmd.Parameters.AddWithValue("@userId", userId);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public UserDetails FollowUser(string email, string userId)
        {
            SqlCommand cmd = new SqlCommand("FollowUser", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            UserDetails user = new UserDetails();
            foreach (DataRow dr in dt.Rows)
            {
                user = new UserDetails()
                {
                    Followers = Convert.ToString(dr["followers"])
                };
            }
            return user;
        }

        public UsersDetailsCombined GetUser(string userID)
        {
            SqlCommand cmd = new SqlCommand("select top 10 * from UserDetails U, AllPhotos A where U.userid=@userID and A.userid=u.userid", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userID);
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
                        Bio = Convert.ToString(dr["bio"]),
                        Followers=Convert.ToString(dr["followers"])
                    };

                user.Photo.Add(
                new Photos()
                {
                    PhotoID = Convert.ToInt32(dr["photoID"]),
                    UserId = Convert.ToInt32(dr["userid"]),
                    ProfilePic = Convert.ToString(dr["profilepic"]),
                    Username = Convert.ToString(dr["username"]),
                    PhotoPath = Convert.ToString(dr["Path"]),
                    LikedBy = (dr["LikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DisLikedBy = (dr["DislikedBy"]).ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    LovedBy = dr["LovedBy"].ToString()/*.Trim(',').Split(',').Select(c => Convert.ToInt32((c != "") ? c : "0")).ToArray()*/,
                    DOU = Convert.ToDateTime(dr["dou"]),
                    ContentType = Convert.ToString(dr["ContentType"]),
                    Video = Convert.ToString(dr["Video"]),
                    Gif = Convert.ToString(dr["Gif"])
                });
                i++;
            }
            return user;
        }

    }
}