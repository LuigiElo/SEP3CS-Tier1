using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SEP3.Models;

namespace SEP3.Pages
{
    
    public class PartyCreated : PageModel
    {
        public Party getParty { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
//        {
//            HttpClient client = new HttpClient();
//            Console.WriteLine(
//                "##########################################################################################################1");
////            var responseMessage =
////                await client.GetAsync("http://10.152.192.113:8080/SEP3_war_exploded/helloworld/fuckyou");
//
////            string s = await responseMessage.Content.ReadAsStringAsync();
////            Console.WriteLine(s);
//
////            if (responseMessage.IsSuccessStatusCode)
////            {
////                Console.WriteLine("##########################################################################################################3");
//////Read response content result into string variable
////                string strJson = responseMessage.Content.ReadAsStringAsync().Result;
//////Deserialize the string to JSON object
////                getParty = (Party) JsonConvert.DeserializeObject(strJson);
////                Console.WriteLine(getParty.ToString());
////              
////                
////            }
//            HttpResponseMessage response =
//                await client.GetAsync("http://10.152.210.113:8080/SEP3_war_exploded/helloworld/fuckyou");
//            Console.WriteLine(
//                "##########################################################################################################2");
//            response.EnsureSuccessStatusCode();
//            Console.WriteLine(
//                "##########################################################################################################2");
//            var resp = await response.Content.ReadAsStringAsync();
//
//            getParty = JsonConvert.DeserializeObject<Party>(resp);
//            Console.WriteLine(getParty.description +
//                              "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
//            return Page();
//        }
//    }
//}
    }
}