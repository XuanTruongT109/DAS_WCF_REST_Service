using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public List<CreditNote> GETCNSID()
        {
            DataSet ds = new DataSet();
            DBHelper db = new DBHelper();
            List<CreditNote> CNs = new List<CreditNote>();
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    log.Error("Cannot open the Database due to: ", ex);
                    return null;
                }
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("spr_GetDataSAPPI", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                DataTable CreNote = ds.Tables[0];
                CNs = CreNote.AsEnumerable().
                    Select(CN => new CreditNote
                    {
                        InterfaceType = CN.Field<string>("INTERFACETYPE"),
                        SalesOrg = CN.Field<string>("SALESORG"),
                        SoldtoParty = CN.Field<string>("SOLDTOPARTY"),
                        ShiptoParty = CN.Field<string>("SHIPTOPARTY"),
                        OrderReason = CN.Field<string>("ORDERREASON"),
                        OrderDate = CN.Field<DateTime>("ORDERDATE").ToString("yyyy-MM-dd HH:mm:ss.fff",
                                CultureInfo.InvariantCulture),
                        RequestDeliveryDate = CN.Field<DateTime>("REQUESTDELIVERYDATE").ToString("yyyy-MM-dd HH:mm:ss.fff",
                                CultureInfo.InvariantCulture),
                        CustomerDocument = CN.Field<string>("CUSTOMERDOCUMENT"),
                        MaterialNumber = CN.Field<string>("MATERIALNUMBER"),
                        OrderQuantity = CN.Field<decimal>("ORDERQUANTITY").ToString(),
                        SalesUnit = CN.Field<string>("SALESUNIT"),
                        ConditionalType = CN.Field<string>("CONDITIONTYPE"),
                        Amount = CN.Field<Decimal>("AMOUNT").ToString(),
                        IONumber = CN.Field<string>("IONUMBER"),
                        GUI = CN.Field<string>("GUI")
                    }).ToList();
                log.Info("Get CreditNotes successfull total record: " + CreNote.Rows.Count);
                return CNs;
            }
            catch (Exception ex)
            {
                log.Error("Cannot get CreditNotes due to: ", ex);
                return null;
            }

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
                        log.Info(Cus.ShiptoName.ToString() + " - Insert to CUSTMSTTABLE success" + result);
                        return;
                    }
                    else
                    {
                        log.Info(Cus.ShiptoName.ToString() + " - Insert to CUSTMSTTABLE fail" + result);
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
