using System.Text.Json;
using Xunit;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string[] urls = { "https://www.google.com", "https://www.bing.com" };

            List<Task> tasks = new List<Task>();

            for (int i = 0;i< urls.Length; i++) {
                tasks.Add( PrintWeb(urls[i]));
            }
            Task.WaitAll(tasks.ToArray());
             



            //HttpClient client = new HttpClient() { BaseAddress = new Uri
            //    ("https://www.google.com")};
            //var response = await client.GetAsync("");
            //Console.WriteLine($" response status = {response.StatusCode}");
            //var r1= JsonSerializer.Serialize(response.Headers);
            //Console.WriteLine(r1);
            //if(response.Headers.Contains("content-type"))
            //{
            //    var result = response.Headers.GetValues("content-type");
            //    Console.WriteLine("Content type : ");
            //    foreach(var str in result)
            //    {
            //        Console.WriteLine(str);
            //    }
            //   // Console.WriteLine(response.Headers["content-type"])
            //}
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public static async Task PrintWeb(string url)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri
                (url)
            };
            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue( "br"));

            var response = await client.GetAsync("");
            Console.WriteLine($" {url} response status = {response.StatusCode}");
            var r1 = JsonSerializer.Serialize(response.Headers);
            Console.WriteLine(r1);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
            //response.Content.ReadAsStream();
        }

        [Fact]
        public void Test()
        {
            PrimeService service = new PrimeService();
            Assert.False(service.IsPrime(1), "1 is not prime num");            


        }




    }
}