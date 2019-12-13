using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEP3.Models;

namespace SEP3.Manager
{
    public class RequestManager
    {
        
        
        
        public async Task<Party> Post(Party party,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(party);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var party2 =   JsonConvert.DeserializeObject<Party>(json);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ToString());

            return party2;
        }
        
        public async Task<Person> Post(Person person,String link)
        {
            Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var person2 = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(response.StatusCode);

            return person2;
        }
        
        public async Task<List<Party>> Get(Person person,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.GetAsync(link);
            var json = await response.Content.ReadAsStringAsync();
            var parties = JsonConvert.DeserializeObject<List<Party>>(json);
            Console.WriteLine(response.StatusCode);

            return parties;
        }
        
        public async Task<List<Person>> GetSearch(Person person,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.GetAsync(link);
            var json = await response.Content.ReadAsStringAsync();
            var people = JsonConvert.DeserializeObject<List<Person>>(json);
            Console.WriteLine(response.StatusCode);

            return people;
        }
        
        
        public async Task<Party> Post(Box box,String link)
        {
            Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(box);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var party = JsonConvert.DeserializeObject<Party>(json);
            Console.WriteLine(response.StatusCode);

            return party;
        }
        
        
        
    }
}