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
    /// <summary>
    /// This is class is used for the communication with the second tier,
    /// it has the all the methods used to consume the webservices.
    /// The idea is that whenever there is something to post or get, the method Post() and Get() are used
    /// according to the object and link needed.
    /// </summary>
    public class RequestManager
    {
        
        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// posting/sending a party that is then added to the database or updated if existent.
        /// </summary>
        /// <param name="party">Party that is going to be sent</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns>The party object that was posted with the updated version from the database.</returns>
        public async Task<Party> Post(Party party, String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(party);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var party2 = JsonConvert.DeserializeObject<Party>(json);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ToString());

            return party2;
        }

        
        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// posting/sending a person that is then added to the database or updated if existent.
        /// </summary>
        /// <param name="person">Person that is going to be sent</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns>The user created</returns>
        public async Task<Person> Post(Person person, String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var person2 = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(response.StatusCode);

            return person2;
        }

        
        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// retrieving a person that is then added to the database or updated if existent.
        /// </summary>
        /// <param name="person">Person to be retrieved</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns>List of parties the user participants in</returns>
        public async Task<List<Party>> Get(Person person, String link)
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

        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// retrieving the result of the search for users.
        /// </summary>
        /// <param name="person">Person to be retrieved</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns>Search results</returns>
        public async Task<List<Person>> GetSearch(Person person, String link)
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


        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// retrieving the result of the search for users.
        /// </summary>
        /// <param name="box">Box with the changes to update</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns>Updated party object</returns>
        public async Task<Party> Post(Box box, String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(box);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var party = JsonConvert.DeserializeObject<Party>(json);
            Console.WriteLine(response.StatusCode);

            return party;
        }


        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// retrieving the invitations for current user.
        /// </summary>
        /// <param name="user">Current user</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns>List of invitations</returns>
        public async Task<List<Invitation>> GetInvites(Person user, string link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.GetAsync(link);
            var json = await response.Content.ReadAsStringAsync();
            var invitations = JsonConvert.DeserializeObject<List<Invitation>>(json);
            Console.WriteLine(response.StatusCode);

            return invitations;
        }
        
        /// <summary>
        /// This method consumes the Tier 2 webservice,
        /// posting the invitations.
        /// </summary>
        /// <param name="invitation">Invitation to someone to some party</param>
        /// <param name="link">Link to access the webservices</param>
        /// <returns></returns>
        public async Task<Invitation> Post(Invitation invitation, String link)
        {
            HttpClient client = new HttpClient();
            string jsonParty = Newtonsoft.Json.JsonConvert.SerializeObject(invitation);
            var content = new StringContent(jsonParty, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(link, content);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Invitation>(json);
            Console.WriteLine(response.StatusCode);

            return result;
        }
        
    }
}