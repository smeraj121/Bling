using ProfilerApp.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProofOfConcept.Models;

namespace ProofOfConcept.Repository
{
    public class UserRepository : IUserRepository
    {
        SqlConnection sqlConnection;
        public UserRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }
        public bool AddUser(User user)
        {
            sqlConnection.Open();
            
            sqlConnection.Close();
            return true;
        }

        public int AuthenticateUser(UserAuth user)
        {
            int userid = 0;
            SqlCommand cmd = new SqlCommand("Select userid from userauth where email=@email and password=@password", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            sqlConnection.Open();
                userid = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            return userid;          
        }
    }
}