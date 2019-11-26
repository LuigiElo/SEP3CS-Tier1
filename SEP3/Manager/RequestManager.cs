using System;
using System.Net.Http;
using System.Text;
using SEP3.Models;

namespace SEP3.Manager
{
    public class RequestManager
    {
        
        
        
        public async void Post(Party party,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(party);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            Console.WriteLine(response.StatusCode);
        }
        
        public async void Post(Person person,String link)
        {
            Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            Console.WriteLine(response.StatusCode);
        }
        
        public async void Get(Person person,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.GetAsync(link);
            Console.WriteLine(response.StatusCode);
        }
        
        
        
        
    }
}