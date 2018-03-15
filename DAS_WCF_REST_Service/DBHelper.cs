using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAS_WCF_REST_Service
{
    public class DBHelper
    {
        private static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            }
        }
        public DataTable GetSelectResult(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, ConnectionString))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetSelectbyStored(string storedName)
        {
            SqlConnection sQLC = new SqlConnection(ConnectionString);
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(storedName, sQLC))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }
    }
}