﻿using System;
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
        
        
        
        
    }
}