using ProfilerApp.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProofOfConcept.Models;
using System.Data;

namespace ProofOfConcept.Repository
{
    public class UserRepository : IUserRepository
    {
        SqlConnection sqlConnection;
        public UserRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        public int AddUser(User user)
        {
            SqlCommand cmd = new SqlCommand("Register", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@role", "User");
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@gender", user.Gender);
            cmd.Parameters.AddWithValue("@dob", user.DOB);
            cmd.Parameters.AddWithValue("@bio", "");
            cmd.Parameters.AddWithValue("@profilepic", "https://res.cloudinary.com/blinging/image/upload/w_200/defaultuser.png");
            sqlConnection.Open();
            int id = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            return id;
        }

        public UserAuth AuthenticateUser(Login user)
        {
            SqlCommand cmd = new SqlCommand("Login", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            UserAuth userauth = new UserAuth();
            foreach (DataRow dr in dt.Rows)
            {
                userauth = new UserAuth
                {
                    UserID = Convert.ToInt32(dr["Userid"]),
                    Role=(dr["role"]).ToString()
                };
            }
            return userauth;
        }

        public bool ForgotPassword(string email,string guid)
        {
            SqlCommand cmd = new SqlCommand("ForgotPassword", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@guid", guid);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public bool MatchGuid(string guid, string email)
        {
            SqlCommand cmd = new SqlCommand("VerifyUser", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@guid", guid);
            sqlConnection.Open();
            int i=(int)cmd.ExecuteScalar();
            sqlConnection.Close();
            if (i == 1)
                return true;
            else return false;
        }

        public bool ChangePassword(ChangePassword changePassword, string userid)
        {
            SqlCommand cmd = new SqlCommand("ChangePassword", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@currentpassword", changePassword.CurrentPassword);
            cmd.Parameters.AddWithValue("@newpassword", changePassword.NewPassword);
            sqlConnection.Open();
            int i = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            if (i == 1)
                return true;
            else return false;
        }
        public bool SetPassword(SetPassword changePassword)
        {
            SqlCommand cmd = new SqlCommand("ChangePassword", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", changePassword.Email);
            cmd.Parameters.AddWithValue("@newpassword", changePassword.NewPassword);
            sqlConnection.Open();
            int i = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            if (i == 1)
                return true;
            else return false;
        }

        public void ResetForgotKey(string email)
        {
            SqlCommand cmd = new SqlCommand("update userauth set guid=null,forgotpassword=0 where email=@email", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            sqlConnection.Open();
            int i = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
        }
    }
}