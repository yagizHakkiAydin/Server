using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BattleOfMinds.MVC.Communication
{
    public class ServiceCommunication : IServiceCommunication
    {
        protected readonly JsonSerializerOptions JsonSerializerOptions;

        public ServiceCommunication()
        {

            JsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
                DefaultBufferSize = 100000,
                MaxDepth = 100,
                IncludeFields = true,

            };
            //JsonSerializerOptions.Converters.Add(new DynamicObjectJsonConverter());
            //JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
        }

        public async Task<HttpResponseMessage> GetResponse(string weburl)
        {
            Uri url = new Uri("https://localhost:7157/");
            using HttpClient client = new HttpClient();
            client.BaseAddress = url;
            using HttpRequestMessage request = new(HttpMethod.Get, weburl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = await client.GetStringAsync(request.RequestUri);
            using HttpResponseMessage result = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return result;
        }

        public async Task<T> GetResponseWithoutToken<T>(string weburl) where T : class
        {
            Uri url = new Uri("https://localhost:7157/");
            using HttpClient client = new HttpClient();
            client.BaseAddress = url;
            var response = await client.GetAsync(weburl);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonresult = response.Content.ReadAsStringAsync().Result;
                var ContentResp = JsonConvert.DeserializeObject<T>(jsonresult);
                return ContentResp;
            }
            return null;
        }

        public async Task<List<T>> GetResponseList<T>(string weburl)
        {
            Uri url = new Uri("https://localhost:7157/");
            using HttpClient client = new HttpClient();
            client.BaseAddress = url;
            var response = await client.GetAsync(weburl);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonresult = response.Content.ReadAsStringAsync().Result;
                var ContentResp = JsonConvert.DeserializeObject<List<T>>(jsonresult);
                return ContentResp;
            }
            return null;
        }
        public async Task<HttpResponseMessage> PostResponse<T>(string weburl, object data)
        {
            return await SendAsync<T>(weburl, HttpMethod.Post, data);
        }

        protected async Task<Stream> SerializeObjectIntoStream(object obj)
        {
            Stream stream = new MemoryStream();
            await System.Text.Json.JsonSerializer.SerializeAsync(stream, obj, JsonSerializerOptions);
            return stream;
        }


        private async Task<HttpResponseMessage> SendAsync<T>(string address, HttpMethod httpMethod, object data)
        {

            Uri url = new Uri("https://localhost:7157/");
            using HttpClient client = new HttpClient();
            client.BaseAddress = url;
            using HttpRequestMessage request = new(httpMethod, address);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using Stream stream = await SerializeObjectIntoStream(data);
            stream.Seek(0, SeekOrigin.Begin);
            using StreamContent requestContent = new(stream);

            if (data != null && httpMethod != HttpMethod.Get && httpMethod != HttpMethod.Delete)
            {
                request.Content = requestContent;

            }

            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var json = await client.GetStringAsync(request.RequestUri);
            using HttpResponseMessage result = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return result;

        }




    }
}
