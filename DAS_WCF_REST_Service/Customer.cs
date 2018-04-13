using System;
using System.Collections.Generic;
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
    }
}