using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAS_WCF_REST_Service
{
    public class Customer
    {
        public string ShiptoName { set; get; }
        public string Cust_Stat { set; get; }
        public string SalesOrg { set; get; }
        public string CustNo { set; get; }
        public string Status { set; get; }
        public int InsertCus(Customer cus, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("spr_INSERT_CUSTMSTTABLE", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShiptoName", SqlDbType.VarChar).Value = cus.ShiptoName;
                cmd.Parameters.Add("@Cust_Stat", SqlDbType.VarChar).Value = cus.Cust_Stat;
                cmd.Parameters.Add("@SalesOrg", SqlDbType.VarChar).Value = cus.SalesOrg;
                cmd.Parameters.Add("@CustNo", SqlDbType.VarChar).Value = cus.CustNo;
                cmd.Parameters.Add("@Status", SqlDbType.Decimal).Value = cus.Status;
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }
    }
}