using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewDB.Models;

namespace NewDB.Controllers
{
    public class HomeController : Controller
    {
        CompanyContext db = new CompanyContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DBWork()
        {
            return View();
        }
        public ActionResult LinqQuery()
        {
            return View();
        }
        [HttpPost]
        public void Edit(int? id, string name, string email, string phone, string site, string action, string industry)
        {
            Company company = db.companies.Where(x => x.CompanyId == id).FirstOrDefault();
            Contact contact = db.contacts.Where(x => x.CompanyId == id).FirstOrDefault();
            if (action == "remove")
            {
                db.companies.Remove(company);
            }
            else if (action == "add")
            {
                company = new Company()
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
            db.companies.Add(company);
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
            Response.Redirect("/Home/DBWork");
        }
    }
}