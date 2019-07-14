using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Multitier_architecture_with_desktop_application
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetRequest("http://www.google.com");
            GetRequestHeades("http://www.microsoft.com");
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
    }
}
