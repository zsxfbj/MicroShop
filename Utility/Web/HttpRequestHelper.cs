using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MicroShop.Utility.Web
{
    /// <summary>
    /// Http请求辅助类
    /// </summary>
    public class HttpRequestHelper
    {       
        /// <summary>
        /// Json内容的Post请求及返回
        /// </summary>
        /// <param name="url">请求的Url地址</param>
        /// <param name="body">请求的内容</param>
        /// <param name="headers">附加的请求头</param>
        /// <returns></returns>
        public static async Task<T?> PostJson<T>(string url, object body, Dictionary<string, string>? headers = null)
        {
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.61 Chrome/126.0.6478.61 Not/A)Brand/8  Safari/537.36")) ;

            if(headers != null)
            {
                foreach(var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(resp);
        }


        /// <summary>
        /// Json内容的Get请求及返回
        /// </summary>
        /// <param name="url">请求的Url地址</param>     
        /// <param name="headers">附加的请求头</param>
        /// <returns></returns>
        public static async Task<T?> GetJson<T>(string url, Dictionary<string, string>? headers = null)
        {
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.61 Chrome/126.0.6478.61 Not/A)Brand/8  Safari/537.36"));

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }         
         
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(resp);
        }
    }
}
