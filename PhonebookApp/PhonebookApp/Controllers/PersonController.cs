using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhonebookApp.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace PhonebookApp.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<Person> list = db.People.ToList();
            List<PersonViewModel> viewList = new List<PersonViewModel>();
            string email = System.Web.HttpContext.Current.User.Identity.Name;
            foreach (Person p in list)
            {
                PersonViewModel obj = new PersonViewModel();
                obj.PersonId = p.PersonId;
                obj.FirstName = p.FirstName;
                obj.MiddleName = p.MiddleName;
                obj.LastName = p.LastName;
                obj.DateOfBirth = Convert.ToDateTime(p.DateOfBirth);
                obj.AddedOn = p.AddedOn;
                obj.AddedBy = p.AddedBy;
                obj.HomeAddress = p.HomeAddress;
                obj.HomeCity = p.HomeCity;
                obj.FaceBookAccountId = p.FaceBookAccountId;
                obj.LinkedInId = p.LinkedInId;
                obj.UpdateOn = Convert.ToDateTime(p.UpdateOn);
                obj.ImagePath = p.ImagePath;
                obj.TwitterId = p.TwitterId;
                obj.EmailId = p.EmailId;
                viewList.Add(obj);
            }
            return View(db.People);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            using (PhoneBookDbEntities db = new PhoneBookDbEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).FirstOrDefault());
            }
           
        }

        // GET: Person/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel obj)
        {

            try
            {
                Person p = new Person();
                p.PersonId = obj.PersonId;
                p.FirstName = obj.FirstName;
                p.MiddleName = obj.MiddleName;
                p.LastName = obj.LastName;
                p.DateOfBirth = obj.DateOfBirth;
                p.AddedOn = DateTime.Now;

                p.HomeAddress = obj.HomeAddress;
                p.HomeCity = obj.HomeCity;
                p.FaceBookAccountId = obj.FaceBookAccountId;
                p.LinkedInId = obj.LinkedInId;
                p.UpdateOn = DateTime.Now;
                p.ImagePath = obj.ImagePath;
                p.TwitterId = obj.TwitterId;
                p.EmailId = obj.EmailId;

                PhoneBookDbEntities db = new PhoneBookDbEntities();
                String ID = "";
                List<AspNetUser> dbList = db.AspNetUsers.ToList();
                foreach (AspNetUser usr in dbList)
                {
                    if (usr.Email == p.EmailId)
                    {
                        ID = usr.Id;
                    }
                }
                p.AddedBy = User.Identity.GetUserId();
                db.People.Add(p);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5

        public ActionResult Edit(int id)
        {

            using (PhoneBookDbEntities db = new PhoneBookDbEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).Single());
            }
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person obj)
        {
            try
            {
                using (PhoneBookDbEntities db = new PhoneBookDbEntities())
                {
                    db.People.Find(id).FirstName = obj.FirstName;
                    db.People.Find(id).MiddleName = obj.MiddleName;
                    db.People.Find(id).LastName = obj.LastName;
                    db.People.Find(id).DateOfBirth = obj.DateOfBirth;
                    db.People.Find(id).HomeAddress = obj.HomeAddress;
                    db.People.Find(id).HomeCity = obj.HomeCity;
                    db.People.Find(id).FaceBookAccountId = obj.FaceBookAccountId;
                    db.People.Find(id).LinkedInId = obj.LinkedInId;
                    db.People.Find(id).ImagePath = obj.ImagePath;
                    db.People.Find(id).TwitterId = obj.TwitterId;
                    db.People.Find(id).EmailId = obj.EmailId;
                    //db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Person p = db.People.Find(id);

            return View(p);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person obj)
        {
            try
            {

                // TODO: Add delete logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var ToDelete = db.People.Single(x => x.PersonId == id);
                foreach(Contact c in db.Contacts)
                {
                    db.Contacts.Remove(c);
                }
                ToDelete.Contacts.Clear();
                db.People.Remove(ToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddContacts(int id)
        {

            using (PhoneBookDbEntities db = new PhoneBookDbEntities())
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddContacts(int id, Contact obj)
        {
            try
            {
                using (PhoneBookDbEntities db = new PhoneBookDbEntities())
                {
                    Person p = db.People.Where(x => x.PersonId == id).Single();
                    p.Contacts.Add(obj);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult ViewContacts(int? id)
        {
            using (PhoneBookDbEntities db = new PhoneBookDbEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).Single().Contacts);
            }
        }
    }
}
