using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hackathon2.APIs
{
    public class FullPageOCRService
    {
        private  HttpClient _httpClient;

        public FullPageOCRService()
        {
            _httpClient = new HttpClient();
        }

        public FullpageocrResponse CallServiceAsync(FullPageOCRRequest requestData)
        {
            _httpClient = new HttpClient();
            string apiURL = APIConstants.BASE_URL + APIConstants.FULLPAGEOCR_URL;
          /*  try
            {*/
                string jsonRequest = JsonConvert.SerializeObject(requestData);
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            //    HttpResponseMessage response =  _httpClient.PostAsync(apiURL, content);
          //  string jsonResponse = response.Content.ReadAsStringAsync();
       //     FullpageocrResponse fullpageocrResponse = JsonConvert.DeserializeObject<FullpageocrResponse>(jsonResponse);
            return null;
            /*   if (response.IsSuccessStatusCode)
               {
                   string jsonResponse =  response.Content.ReadAsStringAsync();
                   FullpageocrResponse fullpageocrResponse = JsonConvert.DeserializeObject<FullpageocrResponse>(jsonResponse);
                   return fullpageocrResponse;
               }
               else
               {
                   Console.WriteLine($"HTTP ERROR: {response.StatusCode}");
                   return null;
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Error: {ex.ToString()}");
               Console.WriteLine(ex.Message);
               return null;
           }*/
        }
    }
}