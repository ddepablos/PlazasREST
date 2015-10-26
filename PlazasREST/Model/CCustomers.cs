using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PlazasREST.Model
{
    [DataContract]
    public class CCustomers
    {
        /* Atributos de Listado de Clientes */
        [DataMember]
        public string docnumber { get; set; }
        [DataMember]
        public string name      { get; set; }
        [DataMember]
        public string lastname1 { get; set; }
        [DataMember]
        public string email     { get; set; }

        /* Atributos de Manejo de Excepciones */
        [DataMember]
        public string exnumber { get; set; }
        [DataMember]
        public string exdetail { get; set; }
    }
}