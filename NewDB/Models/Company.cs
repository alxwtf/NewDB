using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewDB.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string industry { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}