using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProofOfConcept.Models
{
    public class DBReader
    {
        public static T SafeDBReader<T>(SqlDataReader reader, string columnName)
        {
            object o = reader[columnName];

            if (o == DBNull.Value)
            {
                object oo = "";
                return (T)oo;
            }

            return (T)o;
        }
    }
}