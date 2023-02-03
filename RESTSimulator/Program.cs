using Newtonsoft.Json;
using RESTSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RESTSimulator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string serviceURL = ConfigurationManager.AppSettings["RESTurl"];
            var client = new HttpClient();
            Simulator simulator = new Simulator();
            IEnumerable<Customer> customers = simulator.GetCustomers();
            var payload = JsonConvert.SerializeObject(customers);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(serviceURL, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }


    }
}
