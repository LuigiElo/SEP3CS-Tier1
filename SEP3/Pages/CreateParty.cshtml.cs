using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PartyPlanner.Models;

namespace SEP3.Pages{
    public class CreateParty : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Please supply a title")] public string PartyTitle { get; set; }
        [BindProperty, DataType("dd/mm/yyyy", ErrorMessage = "Please provide the date in format dd/mm/yyyy"),Required(ErrorMessage = "Please supply date" )] public string PartyDate { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a location" )]  public string PartyLocation { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a description" )]  public string PartyDescription { get; set; }
        
        public Party Party { get; set; }
        public Person[] People { get; set; }
        
        
        public void OnGet()
        {
            Party = new Party();
            Party.partyTitle = "";
//            Party.date = "";
            Party.location = "";
            PartyDescription = "";


        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            Party = new Party();
            await Task.Delay(0);
            if (ModelState.IsValid)
            {
                if (PartyTitle==null)
                {
                   Console.WriteLine(1111111); 
                }
                else
                {
                    HttpClient client = new HttpClient();
                    
                    Party.partyTitle = PartyTitle;
                   /* string[] Datedetails = PartyDate.Split('/');
                    int day = IntegerType.FromObject(Datedetails[0]);
                    int month = IntegerType.FromObject(Datedetails[1]);
                    int year = IntegerType.FromObject(Datedetails[2]);
                    DateTime dateTimeFormat = new DateTime();
                    */
                   
                    Party.location = PartyLocation;
                    Party.description = PartyDescription;
                    
                    Console.WriteLine(Party.ToString());

                    string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(Party);
                    
                    var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://localhost:8080/SEP3_war_exploded/helloworld/party", content);
                    Console.WriteLine(response.StatusCode);
                    

                    return RedirectToPage("PartyCreated");
                }

                 
            }

            return Page();
        }
    }
}