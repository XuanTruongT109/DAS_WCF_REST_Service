using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS_WCF_REST_Service
{
    public class CreditNote
    {
        public string InterfaceType { set; get; }
        public string SalesOrg { set; get; }
        public string SoldtoParty { set; get; }
        public string ShiptoParty { set; get; }
        public string OrderReason { set; get; }
        public string OrderDate { set; get; }
        public string RequestDeliveryDate { set; get; }
        public string CustomerDocument { set; get; }
        public string MaterialNumber { set; get; }
        public string OrderQuantity { set; get; }
        public string SalesUnit { set; get; }
        public string ConditionalType { set; get; }
        public string Amount { set; get; }
        public string IONumber { set; get; }
        public string GUI { set; get; }
    }
}