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
        [WebInvoke(Method = "GET", UriTemplate = "/GETCNS", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CNs> GETCNSID();
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
        string _SALESORG = string.Empty;
        string _SOLDTOPARTY = string.Empty;
        string _SHIPTOPARTY = string.Empty;
        string _ORDERREASON = string.Empty;
        string _ORDERDATE = string.Empty;
    }
}
