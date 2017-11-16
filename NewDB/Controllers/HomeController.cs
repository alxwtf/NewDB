using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewDB.Models;


namespace NewDB.Controllers
{
    public class HomeController : Controller
    {
        private CompanyContext db = new CompanyContext();

        public ActionResult Index()
        {
            var contacts = db.contacts.Include(c => c.Company);
            return View(contacts.ToList());
        }
        public ActionResult LinqQuery()
        {
            var contacts = db.contacts.Include(c => c.Company);
            return View(contacts.ToList());
        }

        public JsonResult Edit(int? id, string name, string email, string phone, string site, string action, string industry)
        {
            Company company = db.companies.Where(x => x.CompanyId == id).FirstOrDefault();
            Contact contact = db.contacts.Where(x => x.CompanyId == id).FirstOrDefault();
            var comp = new Company();
            if (action == "add")
            {
                comp = new Company
                {
                    Name = name,
                    industry = industry,
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            email = email,
                            phone=phone,
                            site=site
                        }
                    }
                };
                db.companies.Add(comp);
            }
            else if (action == "remove")
            {
                db.companies.Remove(company);
            }
            else if (action == "update")
            {
                if (name != "") company.Name = name;
                if (email != "") contact.email = email;
                if (phone != "") contact.phone = phone;
                if (site != "") contact.site = site;
                if (industry != "") company.industry = industry;
            }
            db.SaveChanges();
            return new JsonResult{Data = comp.CompanyId};
        }
    }
}