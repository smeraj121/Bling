using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        SqlConnection sqlConnection;
        public UserDetailsRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }

        public object EditUserDetails(UserDetails user)
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
            }catch(Exception ex) { i = 1; }
            return false;
        }

        public UserDetails GetUserDetails(string email)
        {
            SqlCommand cmd = new SqlCommand("select * from UserDetails where email=@email", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            UserDetails user= new UserDetails();
            foreach (DataRow dr in dt.Rows)
            {
                user = new UserDetails
                {
                    ProfilePic=Convert.ToString(dr["profilepic"]),
                    UserID = Convert.ToInt32(dr["Userid"]),
                    Email = Convert.ToString(dr["email"]),
                    Username = Convert.ToString(dr["username"]),
                    Name = Convert.ToString(dr["name"]),
                    Gender = Convert.ToString(dr["gender"]),
                    DOB = Convert.ToDateTime(dr["dob"]),
                    Bio=Convert.ToString(dr["bio"])
                };
            }
            return user;
        }

        public string UploadPic(string path, string email)
        {
            SqlCommand cmd = new SqlCommand("select profilepic from userdetails where email=@email", sqlConnection);
            cmd.Parameters.AddWithValue("@email", email);
            sqlConnection.Open();
            string profile = (string)cmd.ExecuteScalar();
            sqlConnection.Close();
            SqlCommand cmd2 = new SqlCommand("update userdetails set profilepic=@profilepic where email=@email", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@profilepic", path);
            cmd2.Parameters.AddWithValue("@email", email);
            sqlConnection.Open();
            int i = cmd2.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {
                return profile;
            }
            else
                return "false";
        }
    }
}