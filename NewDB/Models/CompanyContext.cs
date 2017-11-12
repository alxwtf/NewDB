using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewDB.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Company> companies { get; set; }
    }
}