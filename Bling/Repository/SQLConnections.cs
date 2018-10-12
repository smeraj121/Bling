using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Repository
{
    public class SQLConnections
    {
        public SqlConnection con;
        public SqlConnection Connection()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["Profilercon"].ToString();
            con = new SqlConnection(constring);
            return con;
        }
    }
}