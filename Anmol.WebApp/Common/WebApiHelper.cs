using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Net.Http;
using _Anmol.Common;

namespace _Anmol.WebApp.Common
{

    public class WebApiHelper
    {
        private static string _baseUrl = Convert.ToString(WebConfigurationManager.AppSettings["ApiURL"]);
        // private static string webutility;

        #region WebAPi Common Method

        /// <summary>
        /// HTTPs the client request response.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>Return T object</returns>
        public static async Task<T> HttpClientRequestResponse<T>(T value, string uri, string Token)
        {

            uri = Uri.EscapeUriString(uri);
            WebApiAuthHelper objAuth = new WebApiAuthHelper();
            //AuthenticationHeaderValue token = objAuth.GenerateToken(_baseUrl + uri, "GET");

            var client = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = token;

            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            var response = await client.GetStringAsync(uri);
            if (response.Length > 0)
            {
                var result = JsonConvert.DeserializeObject<T>(response);
                // var result = await response.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result, typeof(T));
            }
            return default(T);
        }


        /// <summary>
        /// HTTPs the client request response synchronize.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>return T object</returns>
        public static T HttpClientRequestResponseSync<T>(T value, string uri, string Token)
        {
            uri = Uri.EscapeUriString(uri);
            WebApiAuthHelper objAuth = new WebApiAuthHelper();
            //AuthenticationHeaderValue token = objAuth.GenerateToken(_baseUrl + uri, "GET");

            var client = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = token;
            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            var httpresult = client.GetAsync(uri).Result;

            if (httpresult.IsSuccessStatusCode)
            {
                var result = httpresult.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result.Result, typeof(T));
            }

            return default(T);
        }

        public static async Task<O> HttpClientPostPassEntityReturnEntity<O, I>(I value, string uri, string Token)
        {
            uri = Uri.EscapeUriString(uri);
            WebApiAuthHelper objAuth = new WebApiAuthHelper();
            //AuthenticationHeaderValue token = objAuth.GenerateToken(_baseUrl + uri, "POST");
            var client = new HttpClient { BaseAddress = new Uri(_baseUrl) };

            // client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = token;
            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            var response = await client.PostAsJsonAsync(uri, value);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<O>();
                return (O)Convert.ChangeType(result, typeof(O));
            }

            return default(O);
        }

        public static async Task<dynamic> GetResponseString(string url, Dictionary<string, string> parameters = null)
        {

            var httpClient = new HttpClient();

            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }
            //var parameters = new Dictionary<string, string>();
            //parameters["text"] = text;

            var response = await httpClient.PostAsync(_baseUrl + url, new FormUrlEncodedContent(parameters));
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }

        public static async Task<T> HttpClientPost<T>(T value, string uri)
        {
            uri = Uri.EscapeUriString(uri);
            HttpResponseMessage response = new HttpResponseMessage();
            WebApiAuthHelper objAuth = new WebApiAuthHelper();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

                if (!string.IsNullOrEmpty(SessionHelper.AuthToken))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionHelper.AuthToken);

                response = await httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(jsonResponse);
                    // var result = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(result, typeof(T));
                    //do something with json response here
                }
            }
            return default(T);
        }

        public static async Task<HttpResponseMessage> HttpClientGet<T>(T value, string uri)
        {
            uri = Uri.EscapeUriString(uri);
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
                response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    //do something with json response here
                }
            }
            return response;
        }
        #endregion
    }
}
