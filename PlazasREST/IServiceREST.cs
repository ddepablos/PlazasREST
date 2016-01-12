using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using PlazasREST.Model;

namespace PlazasREST
{

    [ServiceContract]
    public interface IServiceREST
    {

        #region DummyContracts

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/gettrue")]
        Record GetTrue();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getfalse")]
        Record GetFalse();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getecho/{numero}")]
        Record GetEcho(string numero);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getversion")]
        List<Record> GetVersion();

        #endregion

        #region PlazasMethods
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getclientbynumdoc/{keyword}")]
        CCustomer GetClientByNumDoc(string keyword);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getclientbyname/{keyword}")]
        CCustomer GetClientByName(string keyword);
        //List<CCustomer> GetClientByName(string keyword);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getclients/{keyword}")]
        List<CCustomers> GetClients(string keyword);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "updclient/{id}/{docnumber}/{nationality}/{name}/{name2}/{lastname1}/{lastname2}/{birthdate}/{gender}/{maritalstatus}/{occupation}/{phone1}/{phone2}/{phone3}/{email}/{type}")]
        Record UpdClient(string id, string docnumber, string nationality, string name, string name2, string lastname1, string lastname2, string birthdate, string gender, string maritalstatus, string occupation, string phone1, string phone2, string phone3, string email, string type);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/findclientbyid/{keyword}")]
        Record FindClientById(string keyword);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/findclientbynumdoc/{keyword}")]
        Record FindClientByNumDoc(string keyword);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getsucursales")]
        List<CStore> GetSucursales();

        #endregion

    }

}
