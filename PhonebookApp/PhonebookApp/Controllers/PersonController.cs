﻿using System;
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
            foreach(Person p in list)
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
           /* Person per = db.People.Find(id);
            if(per == null)
            {
                return HttpNotFound();
            }
            return View(per);*/
            //var person = db.People.Single(c => c.PersonId == id);
            //return View(person);
            /*using (PhoneBookDbEntities db = new PhoneBookDbEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).FirstOrDefault());
            }
            */
            /*PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<AspNetUser> user = db.AspNetUsers.ToList();
            string userID = User.Identity.GetUserId().ToString();
            foreach(AspNetUser u in user)
            {
                
            }*/
            /*using (PhoneBookDbEntities db = new PhoneBookDbEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).FirstOrDefault());
            }*/



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
                String ID="";
                List<AspNetUser> dbList=db.AspNetUsers.ToList();
                foreach(AspNetUser usr in dbList)
                {
                    if(  usr.Email==p.EmailId  )
                    {
                        ID=usr.Id;
                    }
                }
                p.AddedBy= User.Identity.GetUserId();
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
        public ActionResult Edit(int id, PersonViewModel obj)
        {
            try
            {
                using (PhoneBookDbEntities db = new PhoneBookDbEntities())
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                    /*var PerId = obj.PersonId;
                    var FirName = obj.FirstName;
                    var MiddleName = obj.MiddleName;
                    var LastName = obj.LastName;
                    var DOB = obj.DateOfBirth;
                    var AddedOn = obj.AddedOn;
                    var AddedBy = obj.AddedBy;
                    var HomeAddress = obj.HomeAddress;
                    var HomeCity = obj.HomeCity;
                    var FaceBookAccountId = obj.FaceBookAccountId;
                    var LinkedInId = obj.LinkedInId;
                    var UpdateOn = DateTime.Now;
                    var ImagePath = obj.ImagePath;
                    var TwitterId = obj.TwitterId;
                    var EmailId = obj.EmailId;
                    // TODO: Add update logic here
                    PhoneBookDbEntities db = new PhoneBookDbEntities();

                    db.SaveChanges();*/
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int?id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int?id, PersonViewModel obj)
        {
            try
            {
                
                // TODO: Add delete logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                if(ModelState.IsValid)
                {
                    var delete = (from d in db.People
                                  where d.PersonId == id
                                  select d).FirstOrDefault();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                    db.People.Remove(delete);
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
