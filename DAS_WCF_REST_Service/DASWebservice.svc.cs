using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DAS_WCF_REST_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DASWebservice" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DASWebservice.svc or DASWebservice.svc.cs at the Solution Explorer and start debugging.
    public class DASWebservice : IDASWebservice
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        public List<CreditNote> GETCNSID()
        {
            throw new NotImplementedException();
        }

        public void AddCustomerTable(Customer Cus)
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    log.Error("Cannot open the Database due to: ", ex);
                    return;
                }
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("spr_INSERT_CUSTMSTTABLE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ShiptoName", SqlDbType.VarChar).Value = Cus.ShiptoName;
                    cmd.Parameters.Add("@Cust_Stat", SqlDbType.VarChar).Value = Cus.Cust_Stat;
                    cmd.Parameters.Add("@SalesOrg", SqlDbType.VarChar).Value = Cus.SalesOrg;
                    cmd.Parameters.Add("@CustNo", SqlDbType.VarChar).Value = Cus.CustNo;
                    cmd.Parameters.Add("@Status", SqlDbType.Decimal).Value = Cus.Status;
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result == 1)
                    {
                        log.Info(Cus.ShiptoName.ToString() + " - Insert to CUSTMSTTABLE success");
                        return;
                    }
                    else
                    {
                        log.Info(Cus.ShiptoName.ToString() + " - Insert to CUSTMSTTABLE fail");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                log.Error(Cus.ShiptoName.ToString() + " - Fail to insert: ", ex);
                return;
            }
        }
        public void AddProductHierarchy(ProHierarchy ProHei)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    log.Error("Cannot open the Database due to: ", ex);
                    return;
                }
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("spr_INSERT_PRODHIERTABLE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BrandCode", SqlDbType.VarChar).Value = ProHei.BrandCode;
                    cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = ProHei.BrandName;
                    cmd.Parameters.Add("@SubBrandCode", SqlDbType.VarChar).Value = ProHei.SubBrandCode;
                    cmd.Parameters.Add("@SubbrandName", SqlDbType.VarChar).Value = ProHei.SubbrandName;
                    cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProHei.ProductID;
                    cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = ProHei.CompanyID;
                    cmd.Parameters.Add("@Status", SqlDbType.Decimal).Value = ProHei.Status;
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result == 1)
                    {
                        log.Info(ProHei.BrandCode.ToString() + " - Insert to CUSTMSTTABLE success");
                        return;
                    }
                    else
                    {
                        log.Info(ProHei.BrandCode.ToString() + " - Insert to CUSTMSTTABLE fail");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                log.Error(ProHei.BrandCode.ToString() + " - Fail to insert: ", ex);
                return;
            }
        }
    }
}
