using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Hackathon2;
using Hackathon2.APIs;
using Newtonsoft.Json;

public class RestApiClient
{
    private readonly HttpClient _httpClient;


    public RestApiClient(string accessToken)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<string> SendImage(string base64Image)
    {
        string apiUrl = APIConstants.BASE_URL + APIConstants.FULLPAGEOCR_URL;
        // Define the OAuth 2.0 parameters

        try
        {
            FullPageOCRRequest requestBody = OCRRequests.PrepareRequestFor(base64Image);

            string jsonRequest = JsonConvert.SerializeObject(requestBody);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public async Task<byte[]> GetFileDataAsync(string fileName)
    {
        string fileUrl = APIConstants.BASE_URL + APIConstants.GETFILE_URL + fileName;
        try
        { 
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");

            HttpResponseMessage response = await _httpClient.GetAsync(fileUrl);
             if (response.IsSuccessStatusCode)
              {
                  // Read the content as a byte array
                  byte[] fileData = await response.Content.ReadAsByteArrayAsync();
                  return fileData;
              }
              else
              {
                  // Handle error responses here
                  Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                  return null;
              }

        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("Error: " + ex.Message);
            return null;
        }
    }

}
