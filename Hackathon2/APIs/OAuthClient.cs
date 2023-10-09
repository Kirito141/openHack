using Hackathon2.APIs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class OAuthClient
{
    private readonly HttpClient _httpClient;
    private readonly string _accessTokenUrl;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _username;
    private readonly string _password;

    public OAuthClient()
    {
        _httpClient = new HttpClient();
        _accessTokenUrl = System.Configuration.ConfigurationManager.AppSettings["accessTokenUrl"];
        _clientId = System.Configuration.ConfigurationManager.AppSettings["clientId"];
        _clientSecret = System.Configuration.ConfigurationManager.AppSettings["clientSecret"];
        _username = System.Configuration.ConfigurationManager.AppSettings["username"];
        _password = System.Configuration.ConfigurationManager.AppSettings["password"];
    }

    public async Task<string> GetAccessTokenAsync()
    {
        try
        {
            // Prepare the credentials for authentication
            string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}"));

            // Prepare the request parameters
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", _username),
                new KeyValuePair<string, string>("password", _password)
            });

            // Set the authorization header using Basic Authentication
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            // Send the request to obtain the access token
            HttpResponseMessage response = await _httpClient.PostAsync(_accessTokenUrl, content);

            if (response.IsSuccessStatusCode)
            {
                // Parse and return the access token from the response
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                return tokenResponse.AccessToken;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }
    }
}
