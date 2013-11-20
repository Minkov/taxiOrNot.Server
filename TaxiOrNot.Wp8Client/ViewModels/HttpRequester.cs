using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace TaxiOrNot.Wp8Client.ViewModels
{
    public class HttpRequester
    {
        public static async Task<T> GetJson<T>(string url, IDictionary<string, string> headers = null)
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.RequestUri = new Uri(url, UriKind.Absolute);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            httpClient.Timeout = TimeSpan.FromSeconds(3000);

            var response = await httpClient.SendAsync(request);            

            var responseContentString = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(responseContentString);
            return model;
        }
    }
}