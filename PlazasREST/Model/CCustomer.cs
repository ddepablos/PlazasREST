using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PlazasREST.Model
{
    [DataContract]
    public class CCustomer
    {
        /* Atributos del Cliente */
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string docnumber { get; set; }
        [DataMember]
        public string nationality { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string name2 { get; set; }
        [DataMember]
        public string lastname1 { get; set; }
        [DataMember]
        public string lastname2 { get; set; }
        [DataMember]
        public string birthdate { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string maritalstatus { get; set; }
        [DataMember]
        public string occupation { get; set; }
        [DataMember]
        public string phone1 { get; set; }
        [DataMember]
        public string phone2 { get; set; }
        [DataMember]
        public string phone3 { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string facebook_account { get; set; }
        [DataMember]
        public string twitter_account { get; set; }
        [DataMember]
        public string instagram_account { get; set; }

        /* Atributos de Manejo de Excepciones */
        [DataMember]
        public string excode { get; set; }
        [DataMember]
        public string exdetail { get; set; }

    }
}