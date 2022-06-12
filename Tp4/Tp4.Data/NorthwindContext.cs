using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Tp4.Entities;

namespace Tp4.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindConnection")
        {
        }

        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
