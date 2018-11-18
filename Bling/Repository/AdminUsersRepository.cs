using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public class AdminUsersRepository : IAdminUsersRepository
    {
        SqlConnection sqlConnection;
        public AdminUsersRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        public bool DeleteUser(int userId)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("delete from userdetails where userid=@userid", sqlConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userId);
                sqlConnection.Open();
                i = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { i = 1; }
            return false;
        }

        public bool EditUser(UserDetails user)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("update userdetails set email=@email, username=@username, name=@name, gender=@gender, dob=@dob , bio=@bio where userid=@userid", sqlConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@dob", user.DOB);
                cmd.Parameters.AddWithValue("@bio", user.Bio);
                cmd.Parameters.AddWithValue("@userid", user.UserID);
                sqlConnection.Open();
                i = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { i = 1; }
            return false;
        }

        public UserDetails GetUser(int userId)
        {
            SqlCommand cmd = new SqlCommand("select * from UserDetails where userId=@userId", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            UserDetails user = new UserDetails();
            foreach (DataRow dr in dt.Rows)
            {
                user = new UserDetails
                {
                    ProfilePic = Convert.ToString(dr["profilepic"]),
                    UserID = Convert.ToInt32(dr["Userid"]),
                    Email = Convert.ToString(dr["email"]),
                    Username = Convert.ToString(dr["username"]),
                    Name = Convert.ToString(dr["name"]),
                    Gender = Convert.ToString(dr["gender"]),
                    DOB = Convert.ToDateTime(dr["dob"]),
                    Bio = Convert.ToString(dr["bio"]),
                    Followers = Convert.ToString(dr["followers"]),
                    Coins = Convert.ToInt32(dr["Coins"])
                };
            }
            return user;
        }

        public List<UserDetails> GetUsers()
        {
            SqlCommand cmd = new SqlCommand("select * from UserDetails", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<UserDetails> users = new List<UserDetails>();
            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new UserDetails()
                {
                    ProfilePic = Convert.ToString(dr["profilepic"]),
                    UserID = Convert.ToInt32(dr["Userid"]),
                    Email = Convert.ToString(dr["email"]),
                    Username = Convert.ToString(dr["username"]),
                    Name = Convert.ToString(dr["name"]),
                    Gender = Convert.ToString(dr["gender"]),
                    DOB = Convert.ToDateTime(dr["dob"]),
                    Bio = Convert.ToString(dr["bio"]),
                    Followers = Convert.ToString(dr["followers"])
                });
            }
            return users;
        }
    }
}