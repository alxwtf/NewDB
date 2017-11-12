using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewDB.Models
{
    public class DBInit : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext db)
        {
            Company company = new Company()
            {
                Name = "РЖД",
                industry = "Перевозки",
                Contacts = new List<Contact>
                {
                    new Contact
                    {
                        email = "123",
                        phone="345",
                        site="567"
                    }
                }
            };
            db.companies.Add(company);
            base.Seed(db);
        }
    }
}
