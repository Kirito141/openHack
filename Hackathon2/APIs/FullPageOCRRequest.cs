using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2.APIs
{
    public class FullPageOCRRequest
    {
        public List<ServiceProp> serviceProps { get; set; }
        public List<RequestItem> requestItems { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class File
    {
        public string name { get; set; }
        public string value { get; set; }
        public string contentType { get; set; }
    }

    public class RequestItem
    {
        public int nodeId { get; set; }
        public List<Value> values { get; set; }
        public List<File> files { get; set; }
    }

   

    public class ServiceProp
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string value { get; set; }
    }


}