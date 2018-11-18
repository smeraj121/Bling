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
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            int id = Convert.ToInt32(cmd.Parameters["@id"].Value);
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
    }
}