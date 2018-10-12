using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PhonebookApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            string email = User.Identity.Name;
            List<Person> ListPerson = new List<Person>();
            foreach(Person p in db.People)
            {
                if(p.EmailId == email)
                {
                    ListPerson.Add(p);
                }
            }
            ViewBag.number = ListPerson.Count();
            
            // List of persons updated within 7 days
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}