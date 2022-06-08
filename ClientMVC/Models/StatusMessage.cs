using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Models
{
        [DataContract]
        public class StatusMessage<T>
        {
            [DataMember(Name = "isSuccess")]
            public bool isSuccess { get; set; }

            [DataMember(Name = "ReturnMessage")]
            public string ReturnMessage { get; set; }

            [DataMember(Name = "Data")]
            public T Data { get; set; }
        }
    }

