using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DAS_WCF_REST_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDASWebservice" in both code and config file together.
    [ServiceContract]
    public interface IDASWebservice
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GETCNS", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CreditNote> GETCNSID();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/CUSTMSTTABLE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddCustomerTable(Customer Cus);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PRODHIERTABLE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddProductHierarchy(ProHierarchy ProHei);
    }
    [DataContract]
    public class CNs
    {
        string _INTERFACETYPE = string.Empty;
        string _SALESORG = string.Empty;
        string _SOLDTOPARTY = string.Empty;
        string _SHIPTOPARTY = string.Empty;
        string _ORDERREASON = string.Empty;
        string _ORDERDATE = string.Empty;
        string _REQUESTDELIVERYDATE = string.Empty;
        string _CUSTOMERDOCUMENT = string.Empty;
        string _MATERIALNUMBER = string.Empty;
        string _ORDERQUANTITY = string.Empty;
        string _SALESUNIT = string.Empty;
        string _CONDITIONTYPE = string.Empty;
        string _AMOUNT = string.Empty;
        string _IONUMBER = string.Empty;
        string _GUI = string.Empty;

        [DataMember]
        public string INTERFACETYPE
        {
            get { return _INTERFACETYPE; }
            set { _INTERFACETYPE = value; }
        }
        [DataMember]
        public string SALESORGE
        {
            get { return _SALESORG; }
            set { _SALESORG = value; }
        }
        [DataMember]
        public string SOLDTOPARTY
        {
            get { return _SOLDTOPARTY; }
            set { _SOLDTOPARTY = value; }
        }
        [DataMember]
        public string SHIPTOPARTY
        {
            get { return _SHIPTOPARTY; }
            set { _SHIPTOPARTY = value; }
        }
        [DataMember]
        public string ORDERREASON
        {
            get { return _ORDERREASON; }
            set { _ORDERREASON = value; }
        }
        [DataMember]
        public string ORDERDATE
        {
            get { return _ORDERDATE; }
            set { _ORDERDATE = value; }
        }
        [DataMember]
        public string REQUESTDELIVERYDATE
        {
            get { return _REQUESTDELIVERYDATE; }
            set { _REQUESTDELIVERYDATE = value; }
        }
        [DataMember]
        public string CUSTOMERDOCUMENT
        {
            get { return _CUSTOMERDOCUMENT; }
            set { _CUSTOMERDOCUMENT = value; }
        }
        [DataMember]
        public string MATERIALNUMBER
        {
            get { return _MATERIALNUMBER; }
            set { _MATERIALNUMBER = value; }
        }
        [DataMember]
        public string ORDERQUANTITY
        {
            get { return _ORDERQUANTITY; }
            set { _ORDERQUANTITY = value; }
        }
        [DataMember]
        public string SALESUNIT
        {
            get { return _SALESUNIT; }
            set { _SALESUNIT = value; }
        }
        [DataMember]
        public string CONDITIONTYPE
        {
            get { return _CONDITIONTYPE; }
            set { _CONDITIONTYPE = value; }
        }
        [DataMember]
        public string AMOUNT
        {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
        [DataMember]
        public string IONUMBER
        {
            get { return _IONUMBER; }
            set { _IONUMBER = value; }
        }
        [DataMember]
        public string GUI
        {
            get { return _GUI; }
            set { _GUI = value; }
        }
    }
}
