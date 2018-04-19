using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAS_WCF_REST_Service
{
    public class ProHierarchy
    {
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string SubBrandCode { get; set; }
        public string SubbrandName { get; set; }
        public string ProductID { get; set; }
        public string CompanyID { get; set; }
        public string Status { get; set; }
        public int Inert_ProHei(ProHierarchy ProH, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("spr_INSERT_PRODHIERTABLE", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BrandCode", SqlDbType.VarChar).Value = ProH.BrandCode;
                cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = ProH.BrandName;
                cmd.Parameters.Add("@SubBrandCode", SqlDbType.VarChar).Value = ProH.SubBrandCode;
                cmd.Parameters.Add("@SubbrandName", SqlDbType.VarChar).Value = ProH.SubbrandName;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProH.ProductID;
                cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = ProH.CompanyID;
                cmd.Parameters.Add("@Status", SqlDbType.Decimal).Value = ProH.Status;
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }
    }
}