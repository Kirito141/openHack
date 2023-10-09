using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Xml.Linq;
using Hackathon2;
using Hackathon2.APIs;
using Newtonsoft.Json;
using System.Text;

namespace Hackathon2
{
    public class OCRRequests
    {
        public static FullPageOCRRequest request = new FullPageOCRRequest();
        public static List<ServiceProp> serviceProps = new List<ServiceProp>();
        public static List<RequestItem> requestItems = new List<RequestItem>();
        public static Value values1;
        public static FullPageOCRRequest PrepareRequestFor(string finalIMG)
        {
            FullPageOCRRequest fullPageOCRRequestrequest = new FullPageOCRRequest {
                serviceProps = new List<ServiceProp>
                {
                    new ServiceProp
                    {
                        name = "Env",
                        value = "D"
                    },
                    new ServiceProp
                    {
                        name = "OcrEngineName",
                        value = "Advanced"
                    }
                },
                requestItems = new List<RequestItem> 
                {
                    new RequestItem
                    {
                        nodeId = 1,
                        values = new List<Value>
                        {
                            new Value 
                            {
                                name = "OutputType",
                                value= "text"
                            }
                        },
                        files = new List<File>
                        {
                            new File
                            {
                                name = "test-doc",
                                value = finalIMG,
                                contentType = "image/png;base64"
                            }
                        }
                    }
                
                }
            };

            return fullPageOCRRequestrequest;
        }

        public static string GetFileNameFromOCRResponse1(string response)
        {
            try
            {
                FullpageocrResponse fullpageocrResponse = JsonConvert.DeserializeObject<FullpageocrResponse>(response);
                return fullpageocrResponse.resultItems[0].files[0].value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
          
        }
    }
}