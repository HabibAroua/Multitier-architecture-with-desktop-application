using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Multitier_architecture_with_desktop_application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //GetRequest("http://www.google.com");
                //GetRequestHeades("http://www.microsoft.com");
                //PostRequest("http://localhost/post/index.php");
                PostRequestJson("http://51.178.169.200/zabbix/api_jsonrpc.php");
            }
            catch(Exception Ex)
            {
                Console.WriteLine("Error : " + Ex.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        async static void GetRequest(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent httpContent = response.Content)
                        {
                            string myContent = await httpContent.ReadAsStringAsync();
                            Console.WriteLine(myContent);
                        }
                    }
                }
            }
            catch(HttpRequestException Ex)
            {
                Console.WriteLine("Error : " + Ex.Message);
                Console.ReadLine();
                Console.WriteLine("Press in any key for exit .....");
                Console.ReadLine();
            }
        }

        async static void GetRequestHeades(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent httpContent = response.Content)
                        {
                            HttpContentHeaders headers = httpContent.Headers;
                            Console.WriteLine(headers);
                        }
                    }
                }
            }
            catch (HttpRequestException Ex)
            {
                Console.WriteLine("Error : " + Ex.Message);
                Console.ReadLine();
                Console.WriteLine("Press in any key for exit .....");
                Console.ReadLine();
            }
        }

        async static void PostRequest(string url)
        {
            try
            {
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("name1","Habib"),
                    new KeyValuePair<string, string>("name2","Safa")
                };
                HttpContent q = new FormUrlEncodedContent(queries);
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(url, q))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string myContent = await content.ReadAsStringAsync();
                            HttpContentHeaders headers = content.Headers;
                            Console.WriteLine(myContent);
                        }
                    }
                }
            }
            catch(HttpRequestException Ex)
            {
                Console.WriteLine("Error : " + Ex.Message);
                Console.ReadLine();
                Console.WriteLine("Press in any key for exit .....");
                Console.ReadLine();
            }
        }

        static void PostRequestJson(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"jsonrpc\": \"2.0\",\"method\": \"user.login\",\"params\": {\"user\": \"Admin\",\"password\": \"zabbix\"},\"id\": 1,\"auth\": null}";
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }
    }
}