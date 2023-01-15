using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ResponseClient
    {
        public string status { get; set; }
        public string message { get; set; }
        public object result { get; set; }
        public object redirect { get; set; }
    }
}