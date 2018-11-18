using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class AdminRepository: IAdminRepository
    {
        SqlConnection sqlConnection;
        public AdminRepository(SQLConnections sqlcon)
        {
            sqlConnection = sqlcon.Connection();
        }

        public List<UserDetails> ViewAdmins() {
            SqlCommand cmd = new SqlCommand("select * from UserDetails where role=Admin", sqlConnection);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            sd.Fill(dt);
            sqlConnection.Close();
            List<UserDetails> users = new List<UserDetails>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new UserDetails
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
                });
            }
            return users;
        }
    }
}