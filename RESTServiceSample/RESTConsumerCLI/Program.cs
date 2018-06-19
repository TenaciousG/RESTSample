using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RESTConsumerCLI
{
    class Program
    {
        //private static string m_resourceUrl = "http://localhost:60958/api/person";
        private static string m_resourceUrl = "http://gol-zb15:8093/api/person";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting REST consuming..");

            ConsumeWithHttpWebRequest();
            ConsumeWithWebClient();
            ConsumeWithHttpClient();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        /*
         * It’s the HTTP-specific implementation of WebRequest class which was originally used to deal with HTTP requests, but it was made obsolete and replaced by the WebClient class.
         */
        private static void ConsumeWithHttpWebRequest()
        {
            Console.WriteLine("Consuming with HttpWebRequest...");

            var request = (HttpWebRequest)WebRequest.Create(m_resourceUrl);
            request.ContentType = "application/json";

            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            var result = JArray.Parse(content);

            Console.WriteLine($"Got result: {result}\n\n\n");
        }

        /*
         * This class is a wrapper around HttpWebRequest. It simplifies the process by abstracting the details of the HttpWebRequest from the developer. The code is easier to write and you are less likely to make mistakes this way. If you want to write less code, not worry about all the details, and the execution speed is a non-factor, consider using WebClient class.
         */
        private static void ConsumeWithWebClient()
        {
            Console.WriteLine("Consuming with WebClient ...");

            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "Text";
            client.Proxy = new WebProxy("http://127.0.0.1:8888");
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var response = client.DownloadString(m_resourceUrl);
            var result_GET = JArray.Parse(response);

            //client.QueryString.Add("param1", "Hello Web Client");
            //var result_POST = client.UploadValues(m_resourceUrl, "POST", client.QueryString);

            //var result_POST = client.UploadString(m_resourceUrl, "POST", "samplestring");

            Console.WriteLine($"GET result: {result_GET}\n\n\n");
            //Console.WriteLine($"POST result: {result_POST}\n\n\n");
        }

        /*
         * HttpClient is the “new kid on the block”, and offers some of the modern .NET functionalities that older libraries lack. For example, you can send multiple requests with the single instance of HttpClient, it is not tied to the particular HTTP server or host, makes use of async/await mechanism.
         */
        private static void ConsumeWithHttpClient()
        {
            Console.WriteLine("Consuming with HttpClient ...");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                var response = httpClient.GetStringAsync(new Uri(m_resourceUrl)).Result;
                var result_GET = JArray.Parse(response);

                var result_POST = httpClient.PostAsync(new Uri(m_resourceUrl), new StringContent("test", Encoding.UTF8, "application/json")).Result;
                result_POST.EnsureSuccessStatusCode();

                Console.WriteLine($"GET result: {result_GET}\n\n\n");
                Console.WriteLine($"POST result: {result_POST.StatusCode}\n\n\n");
            }
        }
    }
}
