using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Tp4.Entities;

namespace Tp4.Entities
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindConnection")
        {
        }

        //public virtual DbSet<Products> Products { get; set; }
        //public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        //public virtual DbSet<Territories> Territories { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Products>()
            //    .Property(e => e.UnitPrice)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<Region>()
            //    .Property(e => e.RegionDescription)
            //    .IsFixedLength();

            //modelBuilder.Entity<Region>()
            //    .HasMany(e => e.Territories)
            //    .WithRequired(e => e.Region)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Territories>()
            //    .Property(e => e.TerritoryDescription)
            //    .IsFixedLength();
        }
    }
}
