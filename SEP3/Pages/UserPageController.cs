using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SEP3.Models;

namespace SEP3.Pages
{
    public class UserPageController : Controller
    {
        public Person user;
        
        IList<Person> studentList = new List<Person>() { 
            new Person(){name= "John"},
            new Person(){name= "Adam"},
            
        };
        // GET: Student
        public ActionResult UserPage()
        {
            ViewBag.Name(studentList[1]);

            return View();
        }
        
    }
}