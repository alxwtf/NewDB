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
        private static CompanyContext db = new CompanyContext();
        private IEnumerable<Contact> contacts = db.contacts.Include(c => c.Company);
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

        public JsonResult Search(string SearchName)
        {
                var query = from t1 in db.companies
                    join t2 in db.contacts on t1.CompanyId equals t2.CompanyId
                    where (t1.Name.Contains(SearchName))
                    select new {t1.Name, t2.email, t2.phone, t2.site, t1.industry};
                var comp = query.ToList();
                return new JsonResult {Data = comp};
        }
    }
}