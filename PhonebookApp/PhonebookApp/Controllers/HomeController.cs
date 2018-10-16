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
            string id = User.Identity.GetUserId();
            List<Person> People = db.People.ToList();
            foreach(Person p in People)
            {
                if(p.AddedBy == id)
                {
                    ListPerson.Add(p);
                }
            }
            ViewBag.number = ListPerson.Count();
            DateTime Today = DateTime.Now;
            DateTime DOB = new DateTime();
            double days;
            TimeSpan time;
            int year = DateTime.Now.Year;
            List<Person> NextBirthdays = new List<Person>();
            foreach(Person per in People)
            {
                if(per.AddedBy == id)
                {
                    DOB = Convert.ToDateTime(per.DateOfBirth);
                    DOB = new DateTime(year, per.DateOfBirth.Value.Month, per.DateOfBirth.Value.Day);
                    time = DOB.Subtract(Today);
                   // days = time.TotalDays;
                    days = time.Days;
                    if(days <=9 && days > 0)
                    {
                        NextBirthdays.Add(per);
                    }
                }
                
            }
            ViewBag.List = NextBirthdays;

            //updated on
            // List of persons updated within 7 days

            DateTime Today1 = DateTime.Now;
            List<Person> Updated = new List<Person>();
            TimeSpan UpdatedTime = new TimeSpan();
            DateTime Up = new DateTime();
            int UpdatedDays;
            foreach(Person pers in People)
            {
                if(pers.AddedBy == id)
                {
                    Up = Convert.ToDateTime(pers.UpdateOn);
                    UpdatedTime = Today1.Subtract(Up);
                    UpdatedDays = UpdatedTime.Days;
                    if(UpdatedDays <=7)
                    {
                        Updated.Add(pers);
                    }
                }
            }
            ViewBag.List1 = Updated;
            return View();
            //return View(NextBirthdays);
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