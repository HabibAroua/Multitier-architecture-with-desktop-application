using System;
using System.Net.Http;

namespace Multitier_architecture_with_desktop_application
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRequest("");
            Console.ReadLine();
        }

        async static void GetRequest(String url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = new HttpResponseMessage())
                {
                    using (HttpContent httpContent = response.Content)
                    {
                        string myContent = await httpContent.ReadAsStringAsync();
                        Console.WriteLine(myContent);
                    }
                }
            }
        }
    }
}
