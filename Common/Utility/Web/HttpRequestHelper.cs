using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroShop.Common.Utility.Web
{
    /// <summary>
    /// Http请求辅助类
    /// </summary>
    public class HttpRequestHelper
    {
        /// <summary>
        /// 默认的User-Agent
        /// </summary>
        public const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.61 Chrome/126.0.6478.61 Not/A)Brand/8  Safari/537.36";

        /// <summary>
        /// Json内容的ContentType
        /// </summary>
        public const string JsonContentType = "application/json";

        #region public static async Task<T> PostJsonAsync<T>(string url, object body, Dictionary<string, string>? headers = null)
        /// <summary>
        /// Json内容的Post请求及返回
        /// </summary>
        /// <param name="url">请求的Url地址</param>
        /// <param name="body">请求的内容</param>
        /// <param name="headers">附加的请求头</param>
        /// <returns></returns>
        public static async Task<T> PostJsonAsync<T>(string url, object body, Dictionary<string, string>? headers = null)
        {
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(DefaultUserAgent)) ;

            if(headers != null)
            {
                foreach(var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(JsonContentType);
            
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(resp);
        }
        #endregion public static async Task<T> PostJsonAsync<T>(string url, object body, Dictionary<string, string>? headers = null)

        #region public static async Task<T> GetJsonAsync<T>(string url, Dictionary<string, string>? headers = null)
        /// <summary>
        /// Json内容的Get请求及返回
        /// </summary>
        /// <param name="url">请求的Url地址</param>     
        /// <param name="headers">附加的请求头</param>
        /// <returns></returns>
        public static async Task<T> GetJsonAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(DefaultUserAgent));

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
        #endregion public static async Task<T> GetJsonAsync<T>(string url, Dictionary<string, string>? headers = null)

        #region public static async Task<string> Download(string srcUrl, string savePath, string fileName = "")
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcUrl"></param>
        /// <param name="savePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static async Task<string> Download(string srcUrl, string savePath, string fileName = "")
        {          
            if (!System.IO.Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            if (string.IsNullOrEmpty(fileName)) {
                string fmtName = srcUrl.Substring(srcUrl.LastIndexOf('.'));
                fileName = StringHelper.GetRandNum(16) + fmtName;
            }


            HttpClient _httpClient = new HttpClient();
            
            // Send a GET request to the specified Uri
            using (var response = await _httpClient.GetAsync(srcUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode(); // Throw if not a success code.
                
                // Path to save the file
                var filePath = Path.Combine(savePath, fileName);

                // Read the content into a MemoryStream and then write to file
                using (var ms = await response.Content.ReadAsStreamAsync())
                using (var fs = File.Create(filePath))
                {
                    await ms.CopyToAsync(fs);
                    fs.Flush();
                }

                return filePath;
            } 
        }
        #endregion public static async Task<string> Download(string srcUrl, string savePath, string fileName = "")

        #region public static T PostJson<T>(string url, object body, Dictionary<string, string>? headers = null)
        /// <summary>
        /// Json内容的Post请求及返回（同步）
        /// </summary>
        /// <param name="url">请求的Url地址</param>
        /// <param name="body">请求的内容</param>
        /// <param name="headers">附加的请求头</param>
        /// <returns></returns>
        public static T PostJson<T>(string url, object body, Dictionary<string, string>? headers = null)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
                request.Headers.UserAgent.Add(new ProductInfoHeaderValue(DefaultUserAgent));

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(JsonContentType);

                HttpResponseMessage response = _httpClient.SendAsync(request).Result;

                response.EnsureSuccessStatusCode();
                var resp = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T>(resp);
            }
        }
        #endregion public static T PostJson<T>(string url, object body, Dictionary<string, string>? headers = null)

        #region public static T GetJson<T>(string url, Dictionary<string, string>? headers = null)
        /// <summary>
        /// Json内容的Get请求及返回（同步）
        /// </summary>
        /// <param name="url">请求的Url地址</param>
        /// <param name="headers">附加的请求头</param>
        /// <returns></returns>
        public static T GetJson<T>(string url, Dictionary<string, string>? headers = null)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
                request.Headers.UserAgent.Add(new ProductInfoHeaderValue(DefaultUserAgent));

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                var response = _httpClient.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                var resp = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T>(resp);
            }
        }
        #endregion public static T GetJson<T>(string url, Dictionary<string, string>? headers = null)

    }
}
