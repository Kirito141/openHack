using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2.APIs
{
   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class FullpageocrResponse
    {
        public ReturnStatus returnStatus { get; set; }
        public int licenseUsedPercent { get; set; }
        public string id { get; set; }
        public string serviceName { get; set; }
        public int executionMilliSeconds { get; set; }
        public List<ResultItem> resultItems { get; set; }
    }


    public class Files
    {
        public string name { get; set; }
        public string value { get; set; }
        public string contentType { get; set; }
        public string src { get; set; }
        public string fileType { get; set; }
    }

    public class ResultItem
    {
        public int nodeId { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public List<object> values { get; set; }
        public List<Files> files { get; set; }
    }

    public class ReturnStatus
    {
        public int status { get; set; }
        public int substatus { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string server { get; set; }
    }

   

}