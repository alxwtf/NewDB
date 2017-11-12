using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewDB.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int CompanyId { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string site { get; set; }

        public Company Company { get; set; }
    }
}