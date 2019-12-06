﻿using System;
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
        
        
        
        public async void Post(Party party,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(party);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ToString());
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
        
        public async void Get(Person person,String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.GetAsync(link);
            Console.WriteLine(response.StatusCode);
        }
        
        
        public async Task<Box> Post(Box box,String link)
        {
            Console.WriteLine("11111111111111111111111111111111111111111111111111111111111111111111111111");
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(box);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var box2 = JsonConvert.DeserializeObject<Box>(json);
            Console.WriteLine(response.StatusCode);

            return box2;
        }
        
        
        
    }
}