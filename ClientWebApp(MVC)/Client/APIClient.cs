//using ClientWebApp_MVC_.Models;
//using Newtonsoft.Json;
//using System;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;


//namespace ClientWebApp_MVC_.Client
//{
//    public partial class APIClient
//    {
//        private readonly HttpClient _httpClient;
//        private Uri BaseEndpoint { get; set; }

//        public APIClient(Uri baseEndpoint)
//        {
//            if (baseEndpoint == null)
//            {
//                throw new ArgumentNullException("baseEndpoint");
//            }
//            BaseEndpoint = baseEndpoint;
//            _httpClient = new HttpClient();
//        }

//        //-----------GET-----------
//        private async Task<T> GetAsync<T>(Uri requestUrl)
//        {
//            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
//            response.EnsureSuccessStatusCode();
//            var data = await response.Content.ReadAsStringAsync();
//            return JsonConvert.DeserializeObject<T>(data);
//        }

//       // -----------POST-----------
//        private async Task<StatusMessage<T>> PostAsync<T>(Uri requestUrl, T content)
//        {
//            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
//            response.EnsureSuccessStatusCode();
//            var data = await response.Content.ReadAsStringAsync();
//            return JsonConvert.DeserializeObject<StatusMessage<T>>(data);
//        }

//        private Uri CreateRequestUri(string relativePath, string queryString = "")
//        {
//            var endpoint = new Uri(BaseEndpoint, relativePath);
//            var uriBuilder = new UriBuilder(endpoint);
//            uriBuilder.Query = queryString;
//            return uriBuilder.Uri;
//        }

//        private HttpContent CreateHttpContent<T>(T content)
//        {
//            var json = JsonConvert.SerializeObject(content);
//            HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
//            return stringContent;
//        }




//    }
//    }
