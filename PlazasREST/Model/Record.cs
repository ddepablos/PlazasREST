using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PlazasREST.Model
{

    [DataContract]
    public class Record
    {
        [DataMember]
        public string excode { get; set; }

        [DataMember]
        public string exdetail { get; set; }
    }

}