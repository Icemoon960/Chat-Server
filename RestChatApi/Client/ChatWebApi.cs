using RestApi.Common;
using RestApi.Contracts;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestChatApi.Client
{
    public class ChatWebApi : IRestApi
    {
        public static class ApiURIs
        {
            public static string host = "localhost";
            public static int port = 50000;
            public static string chats = "Chat";
            public static string messages = "Message";
            public static string user = "User";
            public static string connections = "Connection";
            public static string scheme = "http";
            public static int timeout = 1000000;
        }
        public async Task<HttpResponseMessage> DeleteById(string path, int id, string token = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path, "?id=" + id);
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.DeleteAsync(builder.Uri);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> Delete(string path, string token = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path);
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.DeleteAsync(builder.Uri);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> GetById(string path, int id, string token = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path, "?id=" + id);
                using (HttpClient client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(builder.Uri.ToString());
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(builder.Uri);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> Get(string path, string token = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path);
                using (HttpClient client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(builder.Uri.ToString());
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(builder.Uri);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> Patch(string path, object model, string token = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path);
                StringContent content = model.AsJson();
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.PatchAsync(builder.Uri, content);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> Post(string path, object model, string token = "")
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path);
            StringContent content = model.AsJson();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.PostAsync(builder.Uri, content);
                    response.EnsureSuccessStatusCode();
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> Put(string path, object model, string token = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                UriBuilder builder = new UriBuilder(ApiURIs.scheme, ApiURIs.host, ApiURIs.port, path);
                StringContent content = model.AsJson();
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(ApiURIs.timeout);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.PutAsync(builder.Uri, content);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
