using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WF_TABLE_COUNTRIES_LINQ_ENTITY.Models
{
    internal class CountriesDataContext : DbContext
    {
        public CountriesDataContext() : base("CountriesDB")
        { }

        public DbSet<Countries> contries { get; set; }
    }
}
