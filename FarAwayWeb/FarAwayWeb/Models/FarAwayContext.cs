using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FarAwayWeb.Models
{
    public class FarAwayContext: DbContext
    {
        public FarAwayContext() : base("MSTable_ConnectionString")
        {
            }
        public DbSet<Korisnik2> Korisnik { get; set; }
        public DbSet<UpisUBazu> UpisUBazi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }




    }
}