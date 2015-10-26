using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PlazasREST.Module
{

    [DataContract]
    public class Response
    {

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string detail { get; set; }

        [DataMember]
        public string source { get; set; }

        public string toString() {
            return "{ \"code\" = " + code + ", \"detail\" = " + detail + ", \"source\" = " + source + " }";
        }

    }

}