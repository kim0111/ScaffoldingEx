using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScaffoldingEx.Models
{
    public class ModelAven 
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string HeroName { get; set; }
        public int Age { get; set; }

    }

    public class ModelAvenContext : DbContext
    {
        public DbSet<ModelAven> modelAvens { get; set; }
    }
}